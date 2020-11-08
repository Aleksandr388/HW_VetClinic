using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Models.PostModels
{
    public class PetPostModel
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }

        public ICollection<CreatePetPostModel> VetClinics { get; set; }
    }
}
