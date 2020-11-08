using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Data.Models
{
    public class Communication
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<VetClinic> VetClinics { get; set; }
    }
}
