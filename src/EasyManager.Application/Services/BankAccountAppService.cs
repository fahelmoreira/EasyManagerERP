using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class BankAccountAppService :
        BaseAppService<Domain.Models.BankAccount,
                       BankAccountViewModel,
                       BankAccountShortViewModel,
                       IBankAccountRepository,
                       RegisterNewBankAccountCommand,
                       RemoveBankAccountCommand,
                       UpdateBankAccountCommand>,
        IBankAccountService
    {
        public BankAccountAppService(IMapper mapper, 
                                     IBankAccountRepository repository, 
                                     IMediatorHandler bus, 
                                     IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}