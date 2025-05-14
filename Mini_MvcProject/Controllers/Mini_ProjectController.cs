using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_MvcProject.Data;
using Mini_MvcProject.Migrations;
using Mini_MvcProject.Models;
using Mini_MvcProject.Models.Entities;

namespace Mini_MvcProject.Controllers
{
    public class Mini_ProjectController : Controller
    {
        private readonly AddDbFile dbContext;

        public Mini_ProjectController(AddDbFile dbcontext)
        {
            this.dbContext = dbcontext;
        }
     
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCars viewModel)
        {
            var car = new Car
            {
                Name = viewModel.Name,
                Model_Name = viewModel.Model_Name,
                year = viewModel.year,
                Country = viewModel.Country,
            };
            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var car=await dbContext.Cars.ToListAsync();
            return View(car);

        }

        [HttpGet]

        public async Task<IActionResult> Edit(int Id)
        {
            var car = await dbContext.Cars.FindAsync(Id);
            return View(car);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(AddCars viewModel)
        {
            var car=await dbContext.Cars.FindAsync(viewModel.Id);
            if(car is not null)
            {
                car.Name = viewModel.Name;
                car.Model_Name= viewModel.Model_Name;
                car.year = viewModel.year;
                car.Country = viewModel.Country;

                await dbContext.SaveChangesAsync();

               
            }
            return RedirectToAction("List", "Mini_Project");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(AddCars viewModel)
        {
            var car = await dbContext.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if(car is not null)
            {
                dbContext.Cars.Remove(car);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Mini_Project");
        }
    }
     

    }
