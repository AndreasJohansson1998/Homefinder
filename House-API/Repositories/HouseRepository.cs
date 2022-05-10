using AutoMapper;
using AutoMapper.QueryableExtensions;
using House_API.Data;
using House_API.Interfaces;
using House_API.Models;
using House_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
            return await _context.Houses.ProjectTo<HouseViewModel>(_mapper.ConfigurationProvider).ToListAsync(); ;
        }

        public async Task<List<HouseViewModel>> ListFilteredHousesAsync(string? citySearch, int? minSize, int? maxSize,
            int? minRooms, int? maxRooms, int? minPrice, int? maxPrice)
        {
            IQueryable<House> query = _context.Houses;

            if (minRooms != null || maxRooms != null)
            {
                query = query.Where(h => h.RoomAmount >= (minRooms ?? 0) && h.RoomAmount <= (maxRooms ?? int.MaxValue));
            }

            if (minSize != null || maxSize != null)
            {
                query = query.Where(h => h.LivingArea >= (minSize ?? 0) && h.LivingArea <= (maxSize ?? int.MaxValue));
            }

            if (minPrice != null || maxPrice != null)
            {
                query = query.Where(h => h.Price >= (minPrice ?? 0) && h.Price <= (maxPrice ?? int.MaxValue));
            }

            if (!string.IsNullOrEmpty(citySearch))
            {
                query = query.Where(h => h.City != null).Where(h => h.City!.ToLower().Contains(citySearch.ToLower()));
            }

            return await query.ProjectTo<HouseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<HouseViewModel?> GetHouseByIdAsync(int id)
        {
            return await _context.Houses.Where(h => h.HouseId == id).ProjectTo<HouseViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<PostHouseViewModel> AddHouseAsync(PostHouseViewModel model, IdentityUser user)
        {
            var newHouse = _mapper.Map<House>(model);
            newHouse.User = user;
            await _context.Houses.AddAsync(newHouse);
            return model;
        }

        public async Task UpdateHouseAsync(int id, UpdateHouseViewModel model)
        {
            var response = await _context.Houses.FindAsync(id);

            if (response == null)
            {
                throw new Exception($"Failed to update object with id = {id}");
            }

            _mapper.Map(model, response);

            _context.Houses.Update(response);
        }

        
        public async Task DeleteHouseAsync(int id)
        {
            var response = await _context.Houses.FindAsync(id);

            if (response == null)
            {
                throw new Exception($"Failed to delete object with id = {id}");
            }

            _context.Houses.Remove(response);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}