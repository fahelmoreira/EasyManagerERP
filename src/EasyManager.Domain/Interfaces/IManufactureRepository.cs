using EasyManager.Domain.Models;

namespace EasyManager.Domain.Interfaces
{
    public interface IManufactureRepository : IRepository<IManufactureRepository>
    {
        /// <summary>
        /// Gets the manufacture by it's contact name
        /// </summary>
        /// <param name="fullname">Fullname of the contact person</param>
        /// <returns></returns>
        Manufacture GetByContactName(string fullname);
        /// <summary>
        /// Gets the manufacture by it's trade name
        /// </summary>
        /// <param name="tradename">Trade name of the manufacture</param>
        /// <returns></returns>
        Manufacture GetByTradeName(string tradename);
    }
}