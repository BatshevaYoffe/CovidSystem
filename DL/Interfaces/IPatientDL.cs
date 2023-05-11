using CovidSystem.Entities;

namespace CovidSystem.DL.Interfaces
{
    public interface IPatientDL
    {
        List<Patient> GetPatients();
        Patient GetPatient(string id);
        void AddPatient(Patient patient);
        DateTime GetPatientStart(string id);
        DateTime GetPatientEnd(string id);
        bool IsPatientExist(string id);

    }
}
