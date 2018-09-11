using EasyManager.Domain.Models;

namespace EasyManager.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
         /// <summary>
         /// Gets the customer by it's trade name
         /// </summary>
         /// <param name="tradeName"></param>
         /// <returns></returns>
         Customer GetByTradeName(string tradeName);
         /// <summary>
         /// Gets the customer by it's fullname
         /// </summary>
         /// <param name="fullname">Customer's fullname</param>
         Customer GetByContactName(string fullname);
    }
}