namespace Capstone02.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string Year { get; set; }


        public int PersonId { get; set; }
        public Person Person { get; set; }

        public ICollection<PTAFee> PTAFees { get; set; }
    }
}
