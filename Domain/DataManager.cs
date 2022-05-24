using App.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public IDocumentsRepository Documents { get; set; }
        public IPatientsRepository Patients { get; set; }

        public DataManager(IDocumentsRepository documentsRepository, IPatientsRepository patientsRepository)
        {
            Patients = patientsRepository;
            Documents = documentsRepository;
        }
    }
}
