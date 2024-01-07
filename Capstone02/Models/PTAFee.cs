namespace Capstone02.Models
{
    public class PTAFee
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public required string SchoolYear { get; set; }
        public required string ReferenceNumber { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
