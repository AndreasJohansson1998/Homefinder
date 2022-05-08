using House_API.ViewModels.Interest;
using Microsoft.AspNetCore.Identity;

namespace House_API.Interfaces
{
    public interface IInterestRepository
    {
        public Task<List<InterestViewModel>> ListAllInterestsAsync();
        public Task<InterestViewModel> AddInterestAsync(PostInterestViewModel model, IdentityUser user);
        public Task DeleteInterestAsync(int id);
        public Task<bool> SaveAllAsync();
    }
}