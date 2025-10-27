using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.BLL
{
    using WestWindSystem.DAL;
    using WestWindSystem.Entities;

    public class ShipperServices
    {
        // Setup the context connection variable
        private readonly WestWindContext _context;
        // Define a constructor with dependency on WestWindContext
        internal ShipperServices(WestWindContext registerContext)
        {
            _context = registerContext;
        }

        public List<Shipper> Shipper_GetAll()
        {
            return _context
                    .Shippers
                    .OrderBy(x => x.CompanyName)
                    .ToList();
        }

    }
}
