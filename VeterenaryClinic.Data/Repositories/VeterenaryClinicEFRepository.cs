using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public VetClinic Create(VetClinic model)
        {
            _ctx.VetClinics.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public IEnumerable<VetClinic> GetAll()
        {
            return _ctx.VetClinics.ToList(); 
        }

        public VetClinic GetById(int id)
        {
            return _ctx.VetClinics.FirstOrDefault(x => x.Id == id);
        }

        public VetClinic Update(VetClinic model)
        {
            var entity = _ctx.VetClinics.FirstOrDefault(x => x.Id == model.Id);

            entity.FullNameOwner = model.FullNameOwner;
            entity.Date = model.Date;
            entity.TypeTreatment = model.TypeTreatment;

            _ctx.SaveChanges();

            return model;
        }
        
        public bool Delete(int id)
        {
            try
            {
                var entity = _ctx.VetClinics.FirstOrDefault(x => x.Id == id);

                _ctx.VetClinics.Remove(entity);

                _ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public VetClinic GetByName(string fullName)
        {
            return _ctx.VetClinics.FirstOrDefault(x => x.FullNameOwner == fullName);
        }
    }
}
