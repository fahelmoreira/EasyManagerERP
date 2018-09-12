using System;
using System.Linq;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.Repository
{
    public class ManufactureRepository : Repository<Manufacture>, IManufactureRepository
    {
        public ManufactureRepository(EasyManagerContext context) : base(context)
        {
        }

        public Manufacture GetByContactName(string fullname)
        {
            throw new NotImplementedException();
        }

        public Manufacture GetByTradeName(string tradename)
        {
            throw new NotImplementedException();
        }
    }
}