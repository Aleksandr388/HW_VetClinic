using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;

namespace VeterenaryClinic.Data.Models
{
    public class VetClinic
    {
        public int Id { get; set; }
        public string FullNameOwner { get; set; }
        public DateTime Date { get; set; }
        public string TypeTreatment { get; set; }

        public int PetId { get; set; }
        public virtual Pet Pets { get; set; } 
        public int CommunicationId { get; set; }
        public virtual Communication Communication { get; set; }
    }
}
