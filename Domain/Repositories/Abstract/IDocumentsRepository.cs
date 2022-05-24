using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repositories.Abstract
{
    public interface IDocumentsRepository
    {
        IQueryable<Document> GetDocuments();
        IQueryable<Document> GetDocumentsByPatientId(Guid id);
        Document GetDocumentById(Guid id);
        void SaveDocument(Document entity);
        void DeleteDocument(Guid id);

    }
}
