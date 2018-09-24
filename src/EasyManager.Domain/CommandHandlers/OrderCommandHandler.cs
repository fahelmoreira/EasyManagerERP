using System;
using System.Collections.Generic;
using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;
using MediatR;
using Newtonsoft.Json;

namespace EasyManager.Domain.CommandHandlers
{
    public class OrderCommandHandler :
        BaseCommandsHandler<Order,
                    IOrderRepository,
                    RegisterNewOrderCommand,
                    OrderRegisteredEvent,
                    RemoveOrderCommand,
                    OrderRemovedEvent,
                    UpdateOrderCommand,
                    OrderUpdatedEvent>
    {
        private readonly IDepartamentRepository _departamentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private List<ProductOrder> products;
        private Guid orderID;
        private OrderStatus OrderStatus;

        public OrderCommandHandler(IMapper mapper, 
                                   IOrderRepository repository, 
                                   IDepartamentRepository departamentRepository,
                                   ICustomerRepository customerRepository,
                                   IProductRepository productRepository,
                                   IUnitOfWork uow, 
                                   IMediatorHandler bus, 
                                   INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
            _departamentRepository = departamentRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        protected internal override void ConstraintValidation(Order order, out Order order2)
        {
            Departament departament = null;
            Customer customer = null;
            products = JsonConvert.DeserializeObject<List<ProductOrder>>(order.ProductOrder);
            orderID = order.Id;
            OrderStatus = order.Status;

            bool isValid = true;
            
            //Validates the departament
            if(!order.Departament.IsNull())
            {
                departament = _departamentRepository.GetById(order.Departament.Id);
                if(departament.IsNull())
                {
                    _bus.RaiseEvent(new DomainNotification("Departament invalid", "The departament is not valid"));
                    isValid = false;
                }
            }

            // Validate the Customer
            if(!order.Customer.IsNull())
            {
                customer = _customerRepository.GetById(order.Customer.Id);
                if(departament.IsNull())
                {
                    _bus.RaiseEvent(new DomainNotification("Customer invalid", "The customer is not valid"));
                    isValid = false;
                }
                       
            }

            // validates all products
            foreach (var product in products)
            {
                var p = _productRepository.GetById(product.Id);

                if(p.IsNull())
                {
                    _bus.RaiseEvent(new DomainNotification("Product invalid", $"The product with ID {product.Id} and description {product.Description} is not valid"));
                    isValid = false;
                    continue;
                }

                if(!p.Active)
                {
                    _bus.RaiseEvent(new DomainNotification("Product inactive", $"The product {product.Description} is inactive. Inactive products cannot be sale"));
                    isValid = false;
                    continue;
                }

                product.Description = p.Description;
            }

            if(!isValid)
            {
                order2 = null;
                return;
            }

            UpdateStock();
            order.Customer = customer;
            order.Departament = departament;
            order.ProductOrder = JsonConvert.SerializeObject(products);
            order2 = order;
        }
    
        /// <summary>
        /// Updates the product in stock
        /// </summary>
        private void UpdateStock()
        {
            switch (OrderStatus)
            {
                case OrderStatus.Opened:
                    AddItemToStock();
                    break;
                case OrderStatus.Confirmed:
                    RemoveItemFromStock();
                    break;
                case OrderStatus.Canceled:
                    AddItemToStock();
                    break;
                case OrderStatus.Refunded:
                    AddItemToStock();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds a product to stock
        /// </summary>
        private void AddItemToStock()
        {
            var orderStatus = _repository.GetOrderStatusById(orderID);

            if(orderStatus.IsNull())
                return;

            if((OrderStatus)orderStatus == OrderStatus.Confirmed)
                return;

            foreach (var productEntry in products)
            {
                var productDB = _productRepository.GetById(productEntry.Id); 

                if(productDB.ProductType == ProductType.Bundle)
                {
                    var bundle = _productRepository.GetByIdWithBundle(productEntry.Id); 

                    foreach (var productInfo in bundle.Bundles)
                    {
                        var product = _productRepository.GetById(productInfo.Id); 
                        product.Resale += productInfo.Amount * productEntry.Amount;
                        UpdateProduct(product);
                    }
                }
                else
                {
                    productDB.Resale += productEntry.Amount;
                    UpdateProduct(productDB);
                }
            }
        }

        /// <summary>
        /// Removes a product from stock
        /// </summary>
        private void RemoveItemFromStock()
        {
            var orderStatus = _repository.GetOrderStatusById(orderID);

            if(orderStatus.IsNull())
                return;

            if((OrderStatus)orderStatus == OrderStatus.Confirmed)
                return;

            foreach (var productEntry in products)
            {
                var productDB = _productRepository.GetById(productEntry.Id); 

                if(productDB.ProductType == ProductType.Bundle)
                {
                    var bundle = _productRepository.GetByIdWithBundle(productEntry.Id); 

                    foreach (var productInfo in bundle.Bundles)
                    {
                        var product = _productRepository.GetById(productInfo.Id); 
                        product.Resale -= productInfo.Amount * productEntry.Amount;
                        UpdateProduct(product);
                    }
                }
                else
                {
                    productDB.Resale -= productEntry.Amount;
                    UpdateProduct(productDB);
                }
            }
        }

        private void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }
    }
}