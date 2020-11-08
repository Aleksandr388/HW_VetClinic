using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Domain.Models
{
    public class CommunicationModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<VeterenaryClinicModel> VetClinics { get; set; }
    }
}
