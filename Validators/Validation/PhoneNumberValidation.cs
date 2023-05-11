using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Validation
{
    public class PhoneNumberValidation: IPhoneNumberValidation
    {
        public void IsPhoneNumberValid(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();
            if (phoneNumber.Length != 10 || !long.TryParse(phoneNumber, out long phoneNumberNumber))
            {
                throw new Exception("phone Number is not validate");
            }

            if (!phoneNumber.StartsWith("05"))
            {
                throw new Exception("phone Number is not validate");
            }
        }
    }
}
