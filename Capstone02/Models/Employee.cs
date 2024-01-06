namespace Capstone02.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<PTAFee> PTAFees { get; set; }

    }
}
