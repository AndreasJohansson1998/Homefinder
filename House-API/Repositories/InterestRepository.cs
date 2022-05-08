using AutoMapper;
using AutoMapper.QueryableExtensions;
using House_API.Data;
using House_API.Interfaces;
using House_API.Models;
using House_API.ViewModels.Interest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace House_API.Repositories
{
    public class InterestRepository : IInterestRepository
    {
        private readonly HouseContext _context;
        private readonly IMapper _mapper;

        public InterestRepository(HouseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterestViewModel> AddInterestAsync(PostInterestViewModel model, IdentityUser user)
        {
            var newInterest = new Interest()
            {
                TimeStamp = DateTime.Now,
                User = user,
                House = await _context.Houses.FindAsync(model.HouseId),
            };

            await _context.Interests.AddAsync(newInterest);

            return _mapper.Map<InterestViewModel>(newInterest);
        }

        public async Task DeleteInterestAsync(int id)
        {
            var response =await _context.Interests.FindAsync(id);

            if (response == null)
            {
                throw new Exception($"Failed to delete interest with id = {id}");
            }

            _context.Interests.Remove(response);

        }

        public async Task<List<InterestViewModel>> ListAllInterestsAsync()
        {
            return await _context.Interests.ProjectTo<InterestViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}