using CovidSystem.DL.Interfaces;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Validation
{
    public class IsUserExistValidation : IIsUserExistValidation
    {
        private readonly IUserDL _userDL;

        public IsUserExistValidation(IUserDL userDL)
        {
            _userDL = userDL;
        }

        public void IsUserExistValid(string id)
        {
            if (!_userDL.IsUserExist(id))
            {
                throw new Exception("התעודת זהות לא קיימת");
            }
        }
    }
}
