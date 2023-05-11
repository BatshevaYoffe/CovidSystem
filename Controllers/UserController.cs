using CovidSystem.BL.Interfaces;
using CovidSystem.DB;
using CovidSystem.DL;
using CovidSystem.DL.Interfaces;
using CovidSystem.Entities;
using CovidSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }


        [HttpGet]
        public ResultModel<List<User>>? GetUsers()
        {

            return _userBL.GetUsers();
        }

        [HttpGet("{id}")]
        public ResultModel<User>? GetUser(string id)
        {
            return _userBL.GetUser(id);
        }

        [HttpPost]
        public ResultModel<object> AddUser(User user)
        {
            return _userBL.AddUser(user);
        }

    }
}
