using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStationAPI.LocalControllers;
using ServiceStationAPI.Models;

namespace ServiceStationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase 
    {
        private readonly CategoryLocalController _localController;

        public CategoryController(CategoryLocalController localController)
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

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder(Category category)
        {
            var result = await _localController.Create(category);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Edit")]
        public async Task<IActionResult> EditOrder(Category category)
        {
            var result = await _localController.Edit(category.CategoryId, category.Name);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Delete")]
        public async Task<IActionResult> DeleteOrder(Category category)
        {
            var result = await _localController.Delete(category.CategoryId);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}