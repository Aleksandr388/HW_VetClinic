using System;

namespace VeterenaryClinic.Models.ViewModels
{
    public class VeterenaryClinicVievModel
    {
        public int Id { get; set; }
        public string FullNameOwner { get; set; }
        public DateTime Date { get; set; }
        public string TypeTreatment { get; set; }
    }
}
