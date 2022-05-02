using AutoMapper;
using AutoMapper.QueryableExtensions;
using House_API.Data;
using House_API.Interfaces;
using House_API.Models;
using House_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace House_API.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly HouseContext _context;
        private readonly IMapper _mapper;

        public HouseRepository(HouseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<HouseViewModel>> ListAllHousesAsync()
        {
            return await _context.Houses.ProjectTo<HouseViewModel>(_mapper.ConfigurationProvider).ToListAsync();;
        }

        public async Task<HouseViewModel?> GetHouseByIdAsync(int id)
        {
            return await _context.Houses.Where(h => h.HouseId == id).ProjectTo<HouseViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<HouseViewModel> AddHouseAsync(HouseViewModel model)
        {
            await _context.Houses.AddAsync(_mapper.Map<House>(model));
            return model;
        }
        
        public void DeleteHouse(int id)
        {
            var house = _context.Houses.Find(id);
            if (house != null)
            {
                _context.Houses.Remove(house);
            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}