using House_API.Interfaces;
using House_API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace House_API.Controllers
{
    [ApiController]
    [Route("api/v1/houses")]
    public class HouseController : ControllerBase
    {
        IHouseRepository _houseRepository;
        public HouseController(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
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
        public async Task<ActionResult<HouseViewModel>> AddHouse(HouseViewModel model)
        {
            var response = await _houseRepository.AddHouseAsync(model);
            await _houseRepository.SaveAllAsync();

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHouse(int id, UpdateHouseViewModel model)
        {
            _houseRepository.UpdateHouse(id, model);

            if (await _houseRepository.SaveAllAsync())
            {
                return NoContent();
            }

            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHouse(int id)
        {
            _houseRepository.DeleteHouse(id);

            if (await _houseRepository.SaveAllAsync())
            {
                return NoContent();
            }

            return StatusCode(500);
        }
    }
}