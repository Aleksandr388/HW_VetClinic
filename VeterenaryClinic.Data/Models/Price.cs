using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Data.Models
{
    public class Price
    {
        public int Id { get; set; }
        public double PriceValue { get; set; }

        public virtual ICollection<VetClinic> VetClinics { get; set; }
    }
}
