using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Validation
{
    public class DateValidation: IDateValidation
    {
        public void IsValidDate(DateTime date)
        {
            // בודקים שהתאריך תקין
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
            {
                throw new Exception("תאריך לא תקין");
            }

            var onlyDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            // בודקים שהתאריך עדיין לא עבר
            if (date > onlyDate)
            {
                throw new Exception("תאריך עוד לא היה");
            }

        }

    }
}
