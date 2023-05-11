using CovidSystem.Entities;
using CovidSystem.Models;

namespace CovidSystem.Validators.Vaccination.Interfaces
{
    public interface IAddVaccinationValidator
    {
        string AddVaccinationValidat(VaccinationModel vaccination);

    }
}
