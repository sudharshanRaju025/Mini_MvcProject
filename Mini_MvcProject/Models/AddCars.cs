namespace Mini_MvcProject.Models
{
    public class AddCars
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Model_Name { get; set; } = null!;
        public int year { get; set; }
        public string Country { get; set; } = null!;
    }
}
