using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using House_API.Data;
using House_API.Interfaces;
using House_API.ViewModels;

namespace House_API.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly HouseContext _context;
        public HouseRepository(HouseContext context)
        {
            _context = context;
            
        }
        public async Task<List<HouseViewModel>> ListAllHousesAsync(){
            throw  new NotImplementedException();
        }
    }
}