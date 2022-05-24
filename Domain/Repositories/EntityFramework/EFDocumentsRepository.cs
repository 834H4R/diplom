using App.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repositories.EntityFramework
{
    public class EFDocumentsRepository : IDocumentsRepository
    {

        private readonly AppDbContext context;
        public EFDocumentsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteDocument(Guid id)
        {
            context.Documents.Remove(new Document() { Id = id });
            context.SaveChanges();

        }

        public Document GetDocumentById(Guid id)
        {
            return context.Documents.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Document> GetDocuments()
        {
            return context.Documents;
        }

        public IQueryable<Document> GetDocumentsByPatientId(Guid id)
        {
            return context.Documents.Where(x => x.Patient.Id == id);
        }

        public IQueryable<Document> GetDocumentsByPatientName(string Name)
        {
            return context.Documents.Where(x => x.Patient.Name.Contains(Name));
        }

        public void SaveDocument(Document entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
