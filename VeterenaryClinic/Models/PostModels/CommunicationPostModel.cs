using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Models.PostModels
{
    public class CommunicationPostModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalPhone { get; set; }

        public ICollection<CreatePetPostModel> VetClinics { get; set; }
    }
}
