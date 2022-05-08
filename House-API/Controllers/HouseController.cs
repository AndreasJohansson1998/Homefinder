using House_API.Interfaces;
using House_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace House_API.Controllers
{
    [ApiController]
    [Route("api/v1/houses")]
    public class HouseController : ControllerBase
    {
        private readonly IHouseRepository _houseRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public HouseController(IHouseRepository houseRepository, UserManager<IdentityUser> userManager)
        {
            _houseRepository = houseRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<HouseViewModel>> ListHouses()
        {
            return Ok(await _houseRepository.ListAllHousesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HouseViewModel>> GetHouseById(int id)
        {
            var response = await _houseRepository.GetHouseByIdAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        [Authorize(policy: "Realtor")]
        public async Task<ActionResult<PostHouseViewModel>> AddHouse(PostHouseViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User!.Identity!.Name);

            if (user == null)
            {
                return StatusCode(500);
            }

            var response = await _houseRepository.AddHouseAsync(model, user);

            if (await _houseRepository.SaveAllAsync())
            {
                return StatusCode(201, response);
            }

            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHouse(int id, UpdateHouseViewModel model)
        {
            try
            {
                await _houseRepository.UpdateHouseAsync(id, model);
                if (await _houseRepository.SaveAllAsync())
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHouse(int id)
        {
            try
            {
                await _houseRepository.DeleteHouseAsync(id);
                if (await _houseRepository.SaveAllAsync())
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