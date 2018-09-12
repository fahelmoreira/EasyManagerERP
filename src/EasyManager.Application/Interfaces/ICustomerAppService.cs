using System;
using System.Collections.Generic;
using EasyManager.Application.ViewModels;

namespace EasyManager.Application.Interfaces
{
    public interface ICustomerAppService
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerShortViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
    }
}