using CovidSystem.DB;
using CovidSystem.DL.Interfaces;
using CovidSystem.Entities;

namespace CovidSystem.DL
{
    public class UserDL:IUserDL
    {
        private readonly AppDBContext _dbContext;

        public UserDL(AppDBContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public List<User>? GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User? GetUser(string id)
        {
            return _dbContext.Users.Where(user => user.IdNumber == id).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public bool IsUserExist(string id)
        {
            return _dbContext.Users.Any(user => user.IdNumber == id);
        }

        public DateTime UserBirthDate(string id)
        {
            return _dbContext.Users.FirstOrDefault(user => user.IdNumber == id).BirthDate;
        }
    }
}
