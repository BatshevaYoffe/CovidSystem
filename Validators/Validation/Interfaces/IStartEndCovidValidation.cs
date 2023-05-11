namespace CovidSystem.Validators.Validation.Interfaces
{
    public interface IStartEndCovidValidation
    {
        public bool IsValidDate(DateTime date);
        void IsStartEndCovidValid(CovidSystem.Entities.Patient patient);
    }
}
