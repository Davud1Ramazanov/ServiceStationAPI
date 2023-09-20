using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStationAPI.LocalControllers;
using ServiceStationAPI.Models;
using ServiceStationAPI.Roles;

namespace ServiceStationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        protected readonly CarLocalController _localController;

        public CarController(CarLocalController localController)
        {
            _localController = localController;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Select")]
        public async Task<IActionResult> GetController()
        {
            var result = await _localController.Select();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("SelectUser")]
        public async Task<IActionResult> GetUserController()
        {
            var result = await _localController.SelectUserCar();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Create")]
        public async Task<IActionResult> CreateController(Car car)
        {
            var result = await _localController.Create(car);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Edit")]
        public async Task<IActionResult> EditOrder(Car car)
        {
            var result = await _localController.Edit(car.CarId, car.Name);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Delete")]
        public async Task<IActionResult> DeleteOrder(Car car)
        {
            var result = await _localController.Delete(car.CarId);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
