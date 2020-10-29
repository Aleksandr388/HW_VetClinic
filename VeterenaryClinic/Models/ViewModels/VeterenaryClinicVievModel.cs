using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Models.ViewModels
{
    public class VeterenaryClinicVievModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FullNameOwner { get; set; }
        public DateTime Date { get; set; }
        public string TypeTreatment { get; set; }
        public string Breed { get; set; }
    }
}
