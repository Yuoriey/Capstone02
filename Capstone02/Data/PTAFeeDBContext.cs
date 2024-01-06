using Capstone02.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone02.Data
{
    public class PTAFeeDBContext : DbContext
    {
        public PTAFeeDBContext(DbContextOptions<PTAFeeDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PTAFee> PTAFees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Employee

            builder.Entity<Employee>().HasOne(e => e.Person).WithMany(p => p.Employees).HasForeignKey(e => e.PersonId);
            builder.Entity<Employee>().HasOne(e => e.School).WithMany(p => p.Employees).HasForeignKey(e => e.SchoolId);

            //Parent

            builder.Entity<Parent>().HasOne(e => e.Person).WithMany(p => p.Parents).HasForeignKey(e => e.PersonId);

            //PTAFee

            builder.Entity<PTAFee>().HasOne(e => e.Employee).WithMany(p => p.PTAFees).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<PTAFee>().HasOne(e => e.Student).WithMany(p => p.PTAFees).HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.ClientSetNull);

            //Student

            builder.Entity<Student>().HasOne(e => e.Person).WithMany(p => p.Students).HasForeignKey(e => e.PersonId);



        }
    }

}
