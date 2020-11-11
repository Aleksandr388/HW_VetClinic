using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Domain.Models
{
    public class PriceModel
    {
        public int Id { get; set; }
        public double PriceValue { get; set; }

        public ICollection<VeterenaryClinicModel> VetClinics { get; set; }
    }
}
