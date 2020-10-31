using System.Collections.Generic;
using VeterenaryClinic.Data.Models;
using System.Linq;
using System;

namespace VeterenaryClinic.Data.Repositories
{
    public class VeterenaryClinicRepository
    {
        private List<Models.VeterenaryClinics> VetClinics { get; set; }

        public VeterenaryClinicRepository()
        {
            VetClinics = new List<Models.VeterenaryClinics>();
        }

        public Models.VeterenaryClinics GetByDateTime(DateTime date)
        {
            return VetClinics.FirstOrDefault(x => x.Date.CompareTo(date) == 0);
        }

        public void Create(Models.VeterenaryClinics model)
        {
            VetClinics.Add(model);
        }

        public Models.VeterenaryClinics GetById(int id)
        {
            return VetClinics.FirstOrDefault(x => x.Id == id);
        }
    }
}
