using CovidSystem.Validators.Patient.Interfaces;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Patient
{
    public class AddPatientValidator : IAddPatientValidator
    {

        private readonly IIdNumberValidation _idNumberValidation;
        private readonly IStartEndCovidValidation _startEndCovidValidation;
        private readonly IIsUserExistValidation _isUserExistValidation;
        private readonly IIsPatientExistValidation _isPatientExistValidation;


        public AddPatientValidator(IIdNumberValidation idNumberValidation,IStartEndCovidValidation startEndCovidValidation, IIsUserExistValidation isUserExistValidation, IIsPatientExistValidation isPatientExistValidation)
        {
            _startEndCovidValidation=startEndCovidValidation;
            _idNumberValidation = idNumberValidation;
            _isUserExistValidation=isUserExistValidation;
            _isPatientExistValidation = isPatientExistValidation;
        }

        public string Validat(Entities.Patient patient)
        {
            try
            { 
                _idNumberValidation.IsIdNumberValid(patient.UserId);
                _isUserExistValidation.IsUserExistValid(patient.UserId);
                _isPatientExistValidation.IsPatientExistValid(patient.UserId);
                _startEndCovidValidation.IsStartEndCovidValid(patient);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            //תקינות של כל אחד מהשדות ןהאם המשתמש קיים
            return null;
        }
    }

    
}
