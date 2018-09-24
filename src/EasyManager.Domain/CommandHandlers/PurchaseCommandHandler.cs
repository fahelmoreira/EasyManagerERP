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
    public class PurchaseCommandHandler :
        BaseCommandsHandler<Purchase,
                            IPurchaseRepository,
                            RegisterNewPurchaseCommand,
                            PurchaseRegisteredEvent,
                            RemovePurchaseCommand,
                            PurchaseRemovedEvent,
                            UpdatePurchaseCommand,
                            PurchaseUpdatedEvent>
    {
        private readonly IManufactureRepository _manufactureRepository;
        private readonly IProductRepository _productRepository;
        private List<ProductOrder> products;
        private Guid purchaseID;
        private OrderStatus orderStatus;
        public PurchaseCommandHandler(IMapper mapper, 
                                      IPurchaseRepository repository, 
                                      IManufactureRepository manufactureRepository,
                                      IProductRepository productRepository,
                                      IUnitOfWork uow, 
                                      IMediatorHandler bus, 
                                      INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
            _manufactureRepository = manufactureRepository;
            _productRepository = productRepository;
        }

        protected internal override void ConstraintValidation(Purchase purchase, out Purchase purchase2)
        {
            Manufacture manufacture = null;
            products = JsonConvert.DeserializeObject<List<ProductOrder>>(purchase.Products);
            bool isValid = true;

            // Validates manufacture
            if (!purchase.Manufacture.IsNull())
            {
                manufacture = _manufactureRepository.GetById(purchase.Manufacture.Id);

                if(manufacture.IsNull())
                {
                    _bus.RaiseEvent(new DomainNotification("Manufacture invalid", "The manufacture is not valid"));
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

                product.Description = p.Description;
            }

            if (!isValid)
            {
                purchase2 = null;
                return;
            }

            UpdateStock();
            purchase.Manufacture = manufacture;
            purchase.Products = JsonConvert.SerializeObject(products);
            purchase2 = purchase;
        }

        /// <summary>
        /// Updates the products in stock
        /// </summary>
        private void UpdateStock()
        {
            switch (orderStatus)
            {
                case OrderStatus.Opened:
                    RemoveItemFromStock();
                    break;
                case OrderStatus.Confirmed:
                    AddItemToStock();
                    break;
                case OrderStatus.Canceled:
                    RemoveItemFromStock();
                    break;
                case OrderStatus.Refunded:
                    RemoveItemFromStock();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds the prodcut to stock
        /// </summary>
        private void AddItemToStock()
        {
            var orderStatus = _repository.GetOrderStatusById(purchaseID);

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
        /// Remove product from stock
        /// </summary>
        private void RemoveItemFromStock()
        {
            var orderStatus = _repository.GetOrderStatusById(purchaseID);

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