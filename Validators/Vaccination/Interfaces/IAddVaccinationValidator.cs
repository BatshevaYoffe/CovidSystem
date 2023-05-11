using CovidSystem.Entities;

namespace CovidSystem.Validators.Vaccination.Interfaces
{
    public interface IAddVaccinationValidator
    {
        string AddVaccinationValidat(CovidSystem.Entities.Vaccination vaccination);

    }
}
