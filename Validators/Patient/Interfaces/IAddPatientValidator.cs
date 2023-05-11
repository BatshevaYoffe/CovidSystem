
using CovidSystem.Models;

namespace CovidSystem.Validators.Patient.Interfaces
{
    public interface IAddPatientValidator
    {
        string Validat(PatientModel patient);

    }
}
