namespace Capstone02.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string ChildName { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
