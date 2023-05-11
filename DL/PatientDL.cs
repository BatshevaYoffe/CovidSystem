using CovidSystem.DB;
using CovidSystem.DL.Interfaces;
using CovidSystem.Entities;

namespace CovidSystem.DL
{
    public class PatientDL: IPatientDL
    {
        private readonly AppDBContext _dbContext;

        public PatientDL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPatient(Patient patient)
        {
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();
        }

        public Patient? GetPatient(string id)
        {
            return _dbContext.Patients.Where(patient => patient.UserId == id).FirstOrDefault();
        }

        public DateTime GetPatientEnd(string id)
        {
            return DateTime.Now;
        }

        public List<Patient> GetPatients()
        {
            return _dbContext.Patients.ToList();
        }

        public DateTime GetPatientStart(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsPatientExist(string id)
        {
            return _dbContext.Patients.Any(patient => patient.UserId == id);
        }
    }

}
