using CovidSystem.Entities;
using CovidSystem.Models;

namespace CovidSystem.BL.Interfaces
{
    public interface IPatientBL
    {
        ResultModel<List<Patient>> GetPatients();
        ResultModel<Patient> GetPatient(string id);
        ResultModel<object>AddPatient(PatientModel patient);
        DateTime GetPatientStart(string id);
        DateTime GetPatientEnd(string id);
    }
}
