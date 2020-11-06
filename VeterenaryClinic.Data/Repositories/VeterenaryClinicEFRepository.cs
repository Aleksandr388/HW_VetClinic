using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterenaryClinic.Data.Interfaces;
using VeterenaryClinic.Data.Models;

namespace VeterenaryClinic.Data.Repositories
{
    public class VeterenaryClinicEFRepository : IVeterenaryClinicReposytory
    {
        private readonly VetClinicContext _ctx;

        public VeterenaryClinicEFRepository()
        {
            _ctx = new VetClinicContext();
        }
        public VetClinics Create(VetClinics model)
        {
            _ctx.VetClinics.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public IEnumerable<VetClinics> GetAll()
        {
            throw new NotImplementedException();
        }
        public VetClinics GetById(int id)
        {
            return _ctx.VetClinics.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<VetClinics> GetById()
        {
            throw new NotImplementedException();
        }
    }
}
