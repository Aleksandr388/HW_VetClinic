using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Models.ViewModels
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }

        public ICollection<VeterenaryClinicVievModel> VetClinics { get; set; }
    }
}
