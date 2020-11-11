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
        VetClinic Create(VetClinic model);
        IEnumerable<VetClinic> GetAll();
        VetClinic GetById(int id);
        VetClinic GetByName(string fullName);
    }
}
