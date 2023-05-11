using CovidSystem.BL.Interfaces;
using CovidSystem.DL;
using CovidSystem.DL.Interfaces;
using CovidSystem.Entities;
using CovidSystem.Models;
using CovidSystem.Validators.Patient.Interfaces;
using CovidSystem.Validators.User;
using CovidSystem.Validators.User.Interfaces;

namespace CovidSystem.BL
{
    public class PatientBL : IPatientBL
    {
        private readonly IPatientDL _patientDL;
        private readonly IAddPatientValidator _addPatientValidator;
        private readonly IGetPatientValidator _getPatientValidator;

        public PatientBL(IPatientDL patientDL,IAddPatientValidator addPatientValidator, IGetPatientValidator getPatientValidator)//, IAddPatientValidator addUserValidator)
        {
            _patientDL = patientDL;
            _addPatientValidator = addPatientValidator;
            _getPatientValidator = getPatientValidator;
        }

        public DateTime GetPatientEnd(string id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetPatientStart(string id)
        {
            throw new NotImplementedException();
        }

        ResultModel<object> IPatientBL.AddPatient(Patient patient)
        {
            var error = _addPatientValidator.Validat(patient);

            if (error != null)
            {
                return new ResultModel<object>
                {
                    Success = false,
                    ErrorMessage = error
                };
            }

            try
            {
                _patientDL.AddPatient(patient);
                return new ResultModel<object> { Success = true };
            }
            catch (Exception)
            {
                return new ResultModel<object> { Success = false, ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה" };
            }

        }
    
        ResultModel<Patient> IPatientBL.GetPatient(string id)
        {
            var error = _getPatientValidator.GetPatientValidat(id);

            if (error != null)
            {
                return new ResultModel<Patient>
                {
                    Success = false,
                    ErrorMessage = error
                };
            }
            var patient = _patientDL.GetPatient(id);
            try
            {
                return new ResultModel<Patient>
                {
                    Success = patient != null,
                    Model = patient,
                    ErrorMessage = (patient != null) ? "" : "eror"
                };
            }
            catch (Exception)
            {
                return new ResultModel<Patient>
                {
                    Success = false,
                    ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה"
                };
            }
        }

        ResultModel<List<Patient>> IPatientBL.GetPatients()
        {
            try
            {
                return new ResultModel<List<Patient>>
                {
                    Success = true,
                    Model =_patientDL.GetPatients() //_userDL.GetUsers()
                };
            }
            catch (Exception ex)
            {
                return new ResultModel<List<Patient>>
                {
                    Success = false,
                    ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה"
                };
            }
        }
    }
}
