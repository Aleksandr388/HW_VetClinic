using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using VeterenaryClinic.Data.Models;
using System.Linq;
using System;

namespace VeterenaryClinic.Data.Repositories
{
    public class VeterenaryClinicRepository
    {
        private List<VeterenaryClin> VetClinics { get; set; }

        public VeterenaryClinicRepository()
        {
            VetClinics = new List<VeterenaryClin>();
        }
        public void Create(VeterenaryClin model)
        {
            VetClinics.Add(model);
        }

        public VeterenaryClin GetById(int id)
        {
            return VetClinics.FirstOrDefault(x => x.Id == id);
        }
    }
}
