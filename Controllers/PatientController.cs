using CovidSystem.BL.Interfaces;
using CovidSystem.Entities;
using CovidSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CovidSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientBL _patienceBL;

        public PatientController(IPatientBL patientBL)
        {
            _patienceBL = patientBL;
        }


        [HttpGet]
        public ResultModel<List<Patient>>? GetPatients()
        {

            return _patienceBL.GetPatients();
        }

        [HttpGet("{id}")]
        public ResultModel<Patient>? GetPatient(string id)
        {
            return _patienceBL.GetPatient(id);
        }

        [HttpPost]
        public ResultModel<object> AddPatient(PatientModel user)
        {
            return _patienceBL.AddPatient(user);
        }

    }
}
