using System;

namespace VeterenaryClinic.Domain.Models
{
    public class VeterenaryClinicModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FullNameOwner { get; set; }
        public DateTime Date { get; set; }
        public string TypeTreatment { get; set; }
        public string Breed { get; set; }
    }
}
