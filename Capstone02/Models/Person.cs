namespace Capstone02.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string ChildName { get; set; }


        public ICollection<Employee> Employees { get; set; }
        public ICollection<Parent> Parents { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
