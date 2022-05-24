using App.Domain.Entities;
using App.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repositories.EntityFramework
{
    public class EFPatientsRepository : IPatientsRepository
    {

        private readonly AppDbContext context;
        public EFPatientsRepository(AppDbContext context) { this.context = context; }

        public void DeletePatient(Guid id)
        {
            context.Patients.Remove(new Patient() { Id = id });
            context.SaveChanges();
        }

        public IQueryable<Patient> GetPatients()
        {
            return context.Patients;
        }

        public IQueryable<Patient> GetPatientsByBirthDate(DateTime BirthDate)
        {
            return context.Patients.Where(x => x.BirthDate == BirthDate);

        }

        public IQueryable<Patient> GetPatientsByName(string Name)
        {
            return context.Patients.Where(x => x.Name == Name);
        }

        public Patient GetPatientById(Guid id)
        {
            return context.Patients.FirstOrDefault(x => x.Id == id);

        }

        public void SavePatient(Patient entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
