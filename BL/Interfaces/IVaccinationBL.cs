using CovidSystem.Entities;
using CovidSystem.Models;

namespace CovidSystem.BL.Interfaces
{
    public interface IVaccinationBL
    {
        ResultModel<List<Vaccination>> GetVaccinations();
        ResultModel<Vaccination> GetUserVaccination(string userId);
        ResultModel<object> AddVaccination(Vaccination vaccination);
    }
}
