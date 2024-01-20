using Capstone02.Models;
using Capstone02.Models.PTAFeeType;
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
        public DbSet<Role> Roles {  get; set; }

        public DbSet<Anti_TBFundDrive> Anti_TBFundDrives { get; set; }
        public DbSet<AthleticsSportsFund> aAhleticsSportsFunds { get; set; }
        public DbSet<BoyGirlsScout> BoyGirlsScouts { get; set; }
        public DbSet<GPTAElectricity> GPTAElectricities { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<LearnersAreas> LearnersAreas { get; set; }
        public DbSet<PTAMembership> PTAMemberships { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<RedCross> RedCrosses { get; set; }
        public DbSet<ResearchFund> ResearchFunds { get; set; }
        public DbSet<RFID> RFIDs { get; set; }
        public DbSet<SSG> SSGs {  get; set; }


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
