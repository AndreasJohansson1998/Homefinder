using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using House_API.ViewModels;

namespace House_API.Interfaces
{
    public interface IHouseRepository
    {
         public Task<List<HouseViewModel>> ListAllHousesAsync();
    }
}