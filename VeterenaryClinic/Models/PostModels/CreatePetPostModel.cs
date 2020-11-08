using System;

namespace VeterenaryClinic.Models.PostModels
{
    public class CreatePetPostModel
    {
        public string FullNameOwner { get; set; }
        public DateTime Date { get; set; }
        public string TypeTreatment { get; set; }

        public int PetId { get; set; }
        public PetPostModel Pets { get; set; }
        public int CommunicationId { get; set; }
        public CommunicationPostModel Communication { get; set; }
    }
}
