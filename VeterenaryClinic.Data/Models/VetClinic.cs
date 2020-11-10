using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeterenaryClinic.Data.Models
{
    public class VetClinic
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FullNameOwner { get; set; }
        public string TypeTreatment { get; set; }

        public int PetId { get; set; }
        public virtual Pet Pets { get; set; } 

        public int CommunicationId { get; set; }
        public virtual Communication Communication { get; set; }
    }
}
