namespace Capstone02.Models
{
    public class PTAFee
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public int Amount { get; set; }
        public ICollection<Transaction> Transactions {  get; set; }
    }
}
