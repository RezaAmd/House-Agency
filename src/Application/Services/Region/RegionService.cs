using Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionService
    {
        #region Constructors
        private readonly IDbContext context;

        public RegionService(IDbContext _context)
        {

        }
        #endregion
    }
}
