namespace Capstone02.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
