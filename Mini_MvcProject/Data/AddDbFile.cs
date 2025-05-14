using Microsoft.EntityFrameworkCore;
using Mini_MvcProject.Models.Entities;

namespace Mini_MvcProject.Data
{
    public class AddDbFile:DbContext
    {
        public AddDbFile(DbContextOptions<AddDbFile> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        
    }
}
