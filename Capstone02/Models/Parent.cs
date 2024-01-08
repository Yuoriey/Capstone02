namespace Capstone02.Models
{
    public class Parent
    {
        public int Id { get; set; }

        public required string ParentName { get; set; }
        public required string ContactNumber { get; set; }
        

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
