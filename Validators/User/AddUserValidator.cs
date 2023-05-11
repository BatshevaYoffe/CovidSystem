
using CovidSystem.Validators.User.Interfaces;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.User
{
    public class AddUserValidator : IAddUserValidator
    {
        private readonly IIdNumberValidation _idNumberValidation;
        private readonly IBirthdateValidation _birthdateValidation;
        private readonly IPhoneNumberValidation _phoneNumberValidation;

        public AddUserValidator(IIdNumberValidation idNumberValidation,IPhoneNumberValidation phoneNumberValidation,IBirthdateValidation birthdateValidation)
        {
            _birthdateValidation = birthdateValidation;
            _phoneNumberValidation = phoneNumberValidation;
            _idNumberValidation = idNumberValidation;
        }

        public string Validat(Entities.User user)
        {
            try
            {
                _phoneNumberValidation.IsPhoneNumberValid(user.Mobile);
                _phoneNumberValidation.IsPhoneNumberValid(user.Phone);
                _birthdateValidation.IsBirthdateValid(user.BirthDate);
                _idNumberValidation.IsIdNumberValid(user.IdNumber);
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
