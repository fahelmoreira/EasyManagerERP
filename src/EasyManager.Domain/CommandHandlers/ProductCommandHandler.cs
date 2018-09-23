using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class ProductCommandHandler :
        BaseCommandsHandler<Product,
                            IProductRepository,
                            RegisterNewProductCommand,
                            ProductRegisteredEvent,
                            RemoveProductCommand,
                            ProductRemovedEvent,
                            UpdateProductCommand,
                            ProductUpdatedEvent>
    {
        private readonly IManufactureRepository _manufactureRepository;
        private readonly ICaregoryRepository _caregoryRepository;

        public ProductCommandHandler(IMapper mapper, 
                                     IProductRepository repository, 
                                     IManufactureRepository manufactureRepository,
                                     ICaregoryRepository caregoryRepository,
                                     IUnitOfWork uow, 
                                     IMediatorHandler bus, 
                                     INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
            _manufactureRepository = manufactureRepository;
            _caregoryRepository = caregoryRepository;
        }

        protected internal override void ConstraintValidation(Product product, out Product product2)
        {
            Manufacture manufacture = null;
            Category category = null;
            List<ProductBundle<Product>> bundles = product.Bundles.ToList();
            bool isValid = true; 

            // Validates the manufacture
            if(!product.Manufacture.IsNull())
            {
                manufacture = _manufactureRepository.GetById(product.Manufacture.Id);

                if (manufacture.IsNull())
                {
                    _bus.RaiseEvent(new DomainNotification("Manufacture invalid", "The manufacture is not valid"));
                    isValid = false;
                }
            }
            
            // Validates the manufacture
            if(!product.Category.IsNull())
            {
                category = _caregoryRepository.GetById(product.Category.Id);

                if (category.IsNull())
                {
                    _bus.RaiseEvent(new DomainNotification("Category invalid", "The category is not valid"));
                    isValid = false;
                }
            }

            //Validates the products
            foreach (var p in bundles)
            {
                var pd = _repository.GetById(p.Id);
                if (pd.IsNull())
                {
                    _bus.RaiseEvent(new DomainNotification("Product invalid", $"The product with ID {p.Id} is not valid"));
                    isValid = false;
                    continue;
                }

                p.Product = pd;
            }

            if(!isValid)
            {
                product2 = null;
                return;
            }

            product.Manufacture = manufacture;
            product.Category = category;
            product2 = product;
        } 
    }
}