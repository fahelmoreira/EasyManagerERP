using System;
using System.Collections.Generic;
using EasyManager.Application.ViewModels;

namespace EasyManager.Application.Interfaces
{
    public interface ICustomerAppService : IAppServices<CustomerViewModel, CustomerShortViewModel>
    {
        
    }
}