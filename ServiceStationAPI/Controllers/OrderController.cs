using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStationAPI.LocalControllers;
using ServiceStationAPI.Models;

namespace ServiceStationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderLocalController _localController;

        public OrderController(OrderLocalController localController)
        {
            _localController = localController;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Select")]
        public async Task<IActionResult> GetOrder()
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
        [Route("SelectOrderUser")]
        public async Task<IActionResult> GetUserOrder()
        {
            var result = await _localController.SelectOrderUser();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var result = await _localController.Create(order);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Edit")]
        public async Task<IActionResult> EditOrder(Order order)
        {
            var result = await _localController.Edit(order.OrderId, order.UserName);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Delete")]
        public async Task<IActionResult> DeleteOrder(Order order)
        {
            var result = await _localController.Delete(order.OrderId);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
