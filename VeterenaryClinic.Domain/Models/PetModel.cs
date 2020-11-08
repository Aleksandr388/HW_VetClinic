using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Domain.Models
{
    public class PetModel
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }

        public ICollection<VeterenaryClinicModel> VetClinics { get; set; }
    }
}
