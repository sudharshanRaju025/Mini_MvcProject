using Microsoft.AspNetCore.Mvc;
using Mini_MvcProject.Data;
using Mini_MvcProject.Models;
using Mini_MvcProject.Models.Entities;

namespace Mini_MvcProject.Controllers
{
    public class Mini_ProjectController : Controller
    {
        private readonly AddDbFile dbcontext;

        public Mini_ProjectController(AddDbFile dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
     //private readonly ApplicationDbContext dbContext;
     //   public StudentController(ApplicationDbContext dbContext)
     //   {
     //       this.dbContext = dbContext;
     //   }
     //   [HttpGet]
     //   public IActionResult Add()
     //   {
     //       return View();
     //   }

    }
