using System.Linq;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EasyManager.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EasyManagerContext context) : base(context)
        {
        }

        public Customer GetByContactName(string fullname)
        {
            return DbSet.AsNoTracking().FirstOrDefault(
                x => JsonConvert.DeserializeObject<Contact>(x.Contacts).FullName.ToLower().Contains(fullname.ToLower())
            );
        }

        public Customer GetByTradeName(string tradeName)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.TradeName.ToLower().Contains(tradeName.ToLower()));
        }
    }
}