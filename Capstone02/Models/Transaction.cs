namespace Capstone02.Models
{
	public class Transaction
	{
		public int Id { get; set; }
		public DateTime TransactionDate { get; set; }
		

		public int? EmployeeId { get; set; }
		public virtual Employee Employee { get; set; }

		public int? ParentId { get; set; }
		public virtual Parent Parent { get; set; }

		public int? PTAFeeId { get; set; }
		public virtual PTAFee PTAFee { get; set; }
	}
}
