namespace Capstone02.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public required string Gender { get; set; }
        public required string Address { get; set; }
        public required string EmailAddress { get; set; }
        public required string ContactNumber { get; set; }
        public required string Section { get; set; }
        public required string Year { get; set; }


        public ICollection<Parent> Parents { get; set; }
    }
}
