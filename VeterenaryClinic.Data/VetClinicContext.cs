using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using VeterenaryClinic.Data.Models;

namespace VeterenaryClinic.Data
{
    public class VetClinicContext : DbContext
    {
        public VetClinicContext() : base("Data Source=.;Initial Catalog = VetClinicDataBase; Integrated Security = true")
        {
        }

        public VetClinicContext(string connectonString) : base(connectonString)
        {
        }

        public DbSet<VetClinic> VetClinics { get; set; }    

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Communication> Communications { get; set; }
        public DbSet<Price> Prices { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Communication>()
                .ToTable("Communications")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Communication>()
                .Property(x => x.Phone)
                .HasMaxLength(12); 

            modelBuilder.Entity<Communication>()
                .HasMany(x => x.VetClinics)
                .WithRequired(x => x.Communication)
                .HasForeignKey(x => x.CommunicationId);

            modelBuilder.Entity<Pet>()
                .HasMany(x => x.VetClinics)
                .WithRequired(x => x.Pets)
                .HasForeignKey(x => x.PetId);

            modelBuilder.Entity<Price>()
                .HasMany(x => x.VetClinics)
                .WithRequired(x => x.Prices)
                .HasForeignKey(x => x.PriceId);
        }
    }
}
