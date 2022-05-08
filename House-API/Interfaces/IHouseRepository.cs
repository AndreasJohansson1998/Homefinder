using House_API.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace House_API.Interfaces
{
    public interface IHouseRepository
    {
        public Task<List<HouseViewModel>> ListAllHousesAsync();
        public Task<HouseViewModel?> GetHouseByIdAsync(int id);
        public Task<PostHouseViewModel> AddHouseAsync(PostHouseViewModel model, IdentityUser user);
        public Task UpdateHouseAsync(int id, UpdateHouseViewModel model);
        public Task DeleteHouseAsync(int id);
        public Task<bool> SaveAllAsync();
    }
}