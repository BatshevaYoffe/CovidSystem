using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Validation
{
    public class BirthdateValidation: IBirthdateValidation
    {
        public void IsBirthdateValid(DateTime birthdate)
        {
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime maxDate = DateTime.Today.AddYears(-18);

            if ((birthdate < minDate) || (birthdate > maxDate))
            {
                throw new Exception("birth date is not validate");
            }
        }
    }
}
