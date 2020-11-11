using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Models.ViewModels
{
    public class PriceViewModel
    {
        public int Id { get; set; }
        public decimal PriceValue { get; set; }
        public ICollection<VeterenaryClinicVievModel> VetClinics { get; set; }
    }
}
