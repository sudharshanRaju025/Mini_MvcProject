using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_MvcProject.Data;
using Mini_MvcProject.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_MvcProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsApiController : ControllerBase
    {
        private readonly AddDbFile _dbContext;

        public CarsApiController(AddDbFile dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/CarsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        // GET: api/CarsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _dbContext.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // POST: api/CarsApi
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // PUT: api/CarsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(car).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/CarsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _dbContext.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _dbContext.Cars.Any(e => e.Id == id);
        }
    }
}
