using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone02.Models
{
    public class Parent
    {
        public int Id { get; set; }

        public required string ParentName { get; set; }
        public required string EmailAddress { get; set; }
        public required string ContactNumber { get; set; }
        public required string Password {  get; set; }
        public required int Balance { get; set; }
        public int? StudentId { get; set; }
        public virtual Student? Student { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
        [NotMapped]
        public IFormFile? ProfileImage { get; set; }
    }
}
