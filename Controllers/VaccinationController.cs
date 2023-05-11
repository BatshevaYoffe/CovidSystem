using CovidSystem.BL.Interfaces;
using CovidSystem.Entities;
using CovidSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CovidSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private readonly IVaccinationBL _vaccinationBL;

        public VaccinationController(IVaccinationBL vaccinationBL)
        {
            _vaccinationBL = vaccinationBL;
        }


        [HttpGet]
        public ResultModel<List<Vaccination>>? GetVaccinations()
        {

            return _vaccinationBL.GetVaccinations();
        }

        [HttpGet("{id}")]
        public ResultModel<Vaccination>? GetUserVaccination(string id)
        {
            return _vaccinationBL.GetUserVaccination(id);
        }

        [HttpPost]
        public ResultModel<object> AddVaccination(Vaccination user)
        {
            return _vaccinationBL.AddVaccination(user);
        }

    }
}
