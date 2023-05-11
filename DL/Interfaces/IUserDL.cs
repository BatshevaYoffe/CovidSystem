using CovidSystem.Entities;
using CovidSystem.Models;

namespace CovidSystem.DL.Interfaces
{
    public interface IUserDL
    {
        List<User> GetUsers();
        User GetUser(string id);
        void AddUser(User user);
        bool IsUserExist(string id);
        DateTime UserBirthDate(string id);

    }
}
