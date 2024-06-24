using AppApi.DTOs.Sliders;
using AppApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sliderService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sliderService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _sliderService.GetById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _sliderService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SliderEditDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _sliderService.EditAsync(id, request);

            return Ok();
        }
    }
}
