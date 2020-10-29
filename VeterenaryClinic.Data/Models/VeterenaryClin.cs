using System;

namespace VeterenaryClinic.Data.Models
{
    public class VeterenaryClin
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FullNameOwner { get; set; }
        public DateTime Date { get; set; }
        public string TypeTreatment { get; set; }
        public string Breed { get; set; }
    }
}
