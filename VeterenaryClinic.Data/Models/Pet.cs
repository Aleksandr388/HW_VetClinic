using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Data.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }

        public virtual ICollection<VetClinic> VetClinics { get; set; }
    }
}
