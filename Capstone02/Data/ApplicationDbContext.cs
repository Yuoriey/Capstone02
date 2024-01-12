using Capstone02.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Capstone02.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<PTAFee> PTAFees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Employee

            
            builder.Entity<Employee>()
                .HasOne(e => e.School)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            //Parent

            builder.Entity<Parent>()
                .HasOne(e => e.Student)
                .WithMany(p => p.Parents)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            //Transaction

            builder.Entity<Transaction>()
                .HasOne(e => e. Employee)
                .WithMany(p => p.Transactions)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

			builder.Entity<Transaction>()
				.HasOne(e => e.Parent)
				.WithMany(p => p.Transactions)
				.HasForeignKey(e => e.ParentId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder.Entity<Transaction>()
				.HasOne(e => e.PTAFee)
				.WithMany(p => p.Transactions)
				.HasForeignKey(e => e.PTAFeeId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			//Student





		}
    }

}
