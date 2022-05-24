using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repositories.Abstract
{
    public interface IPatientsRepository
    {
        IQueryable<Patient> GetPatients();
        Patient GetPatientById(Guid id);
        IQueryable<Patient> GetPatientsByName(string Name);
        IQueryable<Patient> GetPatientsByBirthDate(DateTime BirthDate);
        void SavePatient(Patient entity);
        void DeletePatient(Guid id);

    }
}
