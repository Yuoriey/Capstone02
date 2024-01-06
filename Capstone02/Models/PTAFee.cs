namespace Capstone02.Models
{
    public class PTAFee
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public string SchoolYear { get; set; }
        public string ReferenceNumber { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
