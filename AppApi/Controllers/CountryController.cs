using AppApi.Data;
using AppApi.DTOs.Countries;
using AppApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Controllers
{
    public class CountryController : BaseController
    {
        private readonly AppDbContext _contex;
        private readonly IMapper _mapper;

        public CountryController(AppDbContext context, IMapper mapper)
        {
            _contex = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CountryDto>>(await _contex.Countries.AsNoTracking().ToListAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _contex.Countries.AddAsync(_mapper.Map<Country>(request));
            await _contex.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto request)
        {
            var entity = await _contex.Countries.AsNoTracking().FirstOrDefaultAsync(m=>m.Id == id);

            if (entity == null) return NotFound();

            _mapper.Map(request, entity);

            _contex.Countries.Update(entity);

            await _contex.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var entity = await _contex.Countries.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            return Ok(_mapper.Map<CountryDto>(entity));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            var entity = await _contex.Countries.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null) return NotFound();

            _contex.Remove(entity);

            await _contex.SaveChangesAsync();

            return Ok();
        }
    }
}
