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
        VeterenaryClinics Create(VeterenaryClinics model);
        IEnumerable<VeterenaryClinics> GetAll();
        IEnumerable<VeterenaryClinics> GetById();
    }
}
