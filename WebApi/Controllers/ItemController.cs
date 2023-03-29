using api.Domain.Services.Interfaces;
using Manager.VM.ItemVM;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("v1/item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemController
        (
            IItemService itemService
        )
        {
            this.itemService = itemService;
        }

        [HttpGet]
        [Route("{itemCode}")]
        public async Task<IActionResult> Get([FromRoute] string itemCode)
        {
            var response = await itemService.Get(itemCode);

            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList([FromQuery] string? filter = null)
        {
            var response = await itemService.GetList(filter);

            if (response.Any())
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] ItemVM model)
        {
            var response = await itemService.Post(model);

            if (response.Errors != null)
            {
                return BadRequest(response);
            }
            return CreatedAtAction(nameof(Get), new { itemCode = response.ItemCode }, response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put([FromBody] ItemVM model)
        {
            var response = await itemService.Put(model);

            if (response == null)
            {
                return NotFound();
            }
            if (response.Errors != null)
            {
                return BadRequest(response);
            }
            return Ok(model);
        }


        [HttpDelete]
        [Route("{itemCode}")]
        public async Task<IActionResult> Delete([FromRoute] string itemCode)
        {
            var response = await itemService.Delete(itemCode);

            if (response == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
