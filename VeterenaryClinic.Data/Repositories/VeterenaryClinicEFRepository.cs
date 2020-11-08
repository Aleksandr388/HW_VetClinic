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
        public VetClinics Create(VetClinics model)
        {
            _ctx.VetClinics.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public IEnumerable<VetClinics> GetAll()
        {
            return _ctx.VetClinics.ToList(); 
        }
        public VetClinics GetById(int id)
        {
            return _ctx.VetClinics.FirstOrDefault(x => x.Id == id);
        }

        public VetClinics Update(VetClinics model)
        {
            var entity = _ctx.VetClinics.FirstOrDefault(x => x.Id == model.Id);

            entity.FullNameOwner = model.FullNameOwner;
            entity.Phone = model.Phone;
            entity.Date = model.Date;
            entity.TypeTreatment = model.TypeTreatment;
            entity.Breed = model.Breed;

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
    }
}
