using CovidSystem.Validators.Vaccination.Interfaces;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Vaccination
{
    public class AddVaccinationValidator : IAddVaccinationValidator
    {
        private readonly IIdNumberValidation _idNumberValidation;
        private readonly IIsUserExistValidation _isUserExistValidation;
        private readonly IDateValidation _dateValidation ;

        public AddVaccinationValidator(IIdNumberValidation idNumberValidation, IIsUserExistValidation isUserExistValidation, IDateValidation dateValidation)
        {
            _isUserExistValidation = isUserExistValidation;
            _idNumberValidation = idNumberValidation;
            _dateValidation = dateValidation;
        }

        public string AddVaccinationValidat(Entities.Vaccination vaccination)
        {
            try
            {
                _idNumberValidation.IsIdNumberValid(vaccination.UserId);
                _isUserExistValidation.IsUserExistValid(vaccination.UserId);
                _dateValidation.IsValidDate(vaccination.Date);
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
