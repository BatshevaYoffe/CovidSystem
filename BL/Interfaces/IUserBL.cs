using CovidSystem.Entities;
using CovidSystem.Models;

namespace CovidSystem.BL.Interfaces
{
    public interface IUserBL
    {
        ResultModel<List<User>> GetUsers();
        ResultModel<User> GetUser(string id);
        ResultModel<object> AddUser(User user);
    }
}
