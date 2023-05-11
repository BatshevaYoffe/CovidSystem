using CovidSystem.Validators.Vaccination.Interfaces;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Vaccination
{
    public class GetVaccinationValidator : IGetVaccinationValidator
    {

        private readonly IIdNumberValidation _idNumberValidation;

        public GetVaccinationValidator(IIdNumberValidation idNumberValidation)
        {
            _idNumberValidation = idNumberValidation;
        }

        public string GetVaccinationValidat(string userid)
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
