using Microsoft.EntityFrameworkCore;
using Mmi.Core.Domain;

namespace Mmi.DataAccess
{
    public class MedicalInsuranceDb : DbContext
    {
        public DbSet<InsuranceContract> Contracts { get; }
        public DbSet<InsuranceСase> InsuranceСases { get; }
        public DbSet<InsuredPerson> InsuredPersons { get; }

        public MedicalInsuranceDb(DbContextOptions options) : base(options)
        {
            Contracts = Set<InsuranceContract>();
            InsuranceСases = Set<InsuranceСase>();
            InsuredPersons = Set<InsuredPerson>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceContract>()
                .HasMany(contract => contract.InsuranceСases)
                .WithOne(icase => icase.Contract);

            modelBuilder.Entity<InsuredPerson>()
                .HasMany(person => person.Contracts)
                .WithOne(contract => contract.Person);

            base.OnModelCreating(modelBuilder);
        }
    }
}
