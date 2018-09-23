using System;
using System.Collections.Generic;
using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
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
            List<ProductOrder> products = JsonConvert.DeserializeObject<List<ProductOrder>>(purchase.Products);
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

            purchase2 = purchase;
        }
    }
}