using AutoMapper.Configuration.Conventions;
using System;
using VeterenaryClinic.Data.Models;

namespace VeterenaryClinic.Domain.Models
{
    public class VeterenaryClinicModel
    {
        public int Id { get; set; }
        public string FullNameOwner { get; set; }
        public DateTime Date { get; set; }
        public string TypeTreatment { get; set; }

        public int PetId { get; set; }
        public PetModel Pets { get; set; }

        public int CommunicationId { get; set; }
        public CommunicationModel Communication { get; set; }

        public int PriceId { get; set; }
        public PriceModel Prices { get; set; }

    }
}
