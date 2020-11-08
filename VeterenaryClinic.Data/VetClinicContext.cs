using System.Data.Entity;
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

    }
}
