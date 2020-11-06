using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterenaryClinic.Data.Models;
using VeterenaryClinic.Data.Repositories;

namespace VeterenaryClinic.Data.Interfaces
{
    public interface IVeterenaryClinicReposytory
    {
        VetClinics Create(VetClinics model);
        IEnumerable<VetClinics> GetAll();
        VetClinics GetById(int id);
    }
}
