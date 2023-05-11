using CovidSystem.Validators.User.Interfaces;
using CovidSystem.Validators.Validation;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.User
{
    public class GetUserValidator: IGetUserValidator
    {
        private readonly IIdNumberValidation _idNumberValidation;

        public GetUserValidator(IIdNumberValidation idNumberValidation)
        {
            _idNumberValidation = idNumberValidation;
        }

        public string GetValidat(string userid)
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
