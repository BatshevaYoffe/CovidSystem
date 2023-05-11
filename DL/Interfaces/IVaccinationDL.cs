using CovidSystem.Entities;

namespace CovidSystem.DL.Interfaces
{
    public interface IVaccinationDL
    {
        List<Vaccination> GetVaccinations();
        Vaccination GetUserVaccination(string userId);
        void AddVaccination(Vaccination vaccination);
    }
}
