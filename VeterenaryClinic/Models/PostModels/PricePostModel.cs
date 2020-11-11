using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinic.Models.PostModels
{
    public class PricePostModel
    {
        public int Id { get; set; }
        public double PriceValue { get; set; }

        public ICollection<CreatePetPostModel> VetClinics { get; set; }
    }
}
