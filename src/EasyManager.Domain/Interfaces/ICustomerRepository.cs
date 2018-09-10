using EasyManager.Domain.Models;

namespace EasyManager.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<ICustomerRepository>
    {
        /// <summary>
        /// Gets the customer by it's email
        /// </summary>
        /// <param name="email">Customer's email</param>
         Customer GetByEmail(string email);
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