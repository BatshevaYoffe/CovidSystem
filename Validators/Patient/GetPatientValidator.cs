using CovidSystem.Validators.Patient.Interfaces;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Patient
{
    public class GetPatientValidator: IGetPatientValidator
    {
        private readonly IIdNumberValidation _idNumberValidation;

        public GetPatientValidator(IIdNumberValidation idNumberValidation)
        {
            _idNumberValidation = idNumberValidation;
        }

        public string GetPatientValidat(string userid)
        {
            try
            {
                _idNumberValidation.IsIdNumberValid(userid);
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
