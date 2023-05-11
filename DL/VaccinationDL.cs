using CovidSystem.DB;
using CovidSystem.DL.Interfaces;
using CovidSystem.Entities;

namespace CovidSystem.DL
{
    public class VaccinationDL : IVaccinationDL
    {
        private readonly AppDBContext _dbContext;

        public VaccinationDL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddVaccination(Vaccination vaccination)
        {
            _dbContext.Vaccinations.Add(vaccination);
            _dbContext.SaveChanges();
        }

        public List<Vaccination> GetVaccinations()
        {
            return _dbContext.Vaccinations.ToList();
        }

        public Vaccination? GetUserVaccination(string userId)
        {
            return _dbContext.Vaccinations.Where(vac => vac.UserId == userId).FirstOrDefault();
        }
    }
}
