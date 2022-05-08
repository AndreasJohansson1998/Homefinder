using House_API.Interfaces;
using House_API.ViewModels.Interest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace House_API.Controllers
{
    [ApiController]
    [Route("api/v1/interests")]
    public class InterestController : ControllerBase
    {
        private readonly IInterestRepository _interestRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public InterestController(IInterestRepository interestRepository, UserManager<IdentityUser> userManager)
        {
            _interestRepository = interestRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<InterestViewModel>> ListAllInterests()
        {
            return Ok(await _interestRepository.ListAllInterestsAsync());
        }

        [HttpPost]
        [Authorize(policy: "User")]
        public async Task<ActionResult<InterestViewModel>> AddInterest(PostInterestViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User!.Identity!.Name);

            if (user == null)
            {
                return StatusCode(500);
            }

            var result = await _interestRepository.AddInterestAsync(model, user);

            if (await _interestRepository.SaveAllAsync())
            {
                return StatusCode(201, result);
            }

            return StatusCode(500);
        }

        [HttpPost("{id}")]
        [Authorize(policy: "User")]
        public async Task<ActionResult> DeleteInterest(int id)
        {
            try
            {
                await _interestRepository.DeleteInterestAsync(id);
                if (await _interestRepository.SaveAllAsync())
                {
                    return NoContent();
                }
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}