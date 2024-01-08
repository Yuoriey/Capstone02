namespace Capstone02.Models
{
    public class Employee
    {
        public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
        public required string Type { get; set; }
        public required string Position { get; set; }
		public int Age { get; set; }
		public required string Gender { get; set; }
		public required string Address { get; set; }
		public required string EmailAddress { get; set; }
		public required string ContactNumber { get; set; }
		

        public int? SchoolId { get; set; }
        public virtual School School { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
