using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Models.ViewModels
{
    public class CommunicationViewModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalPhone { get; set; }

        public ICollection<VeterenaryClinicVievModel> VetClinics { get; set; }
    }
}
