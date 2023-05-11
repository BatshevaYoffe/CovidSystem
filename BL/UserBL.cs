using CovidSystem.BL.Interfaces;
using CovidSystem.DB;
using CovidSystem.DL;
using CovidSystem.DL.Interfaces;
using CovidSystem.Entities;
using CovidSystem.Models;
using CovidSystem.Validators.User.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CovidSystem.BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDL _userDL;
        private readonly IAddUserValidator _addUserValidator;
        private readonly IGetUserValidator _getUserValidator;
        

        public UserBL(IUserDL userDL, IAddUserValidator addUserValidator,IGetUserValidator getUserValidator)
        {
            _userDL = userDL;
            _addUserValidator = addUserValidator;
            _getUserValidator = getUserValidator;
        }


        //להוסיף תקינות קלט?
        ResultModel<List<User>> IUserBL.GetUsers()
        {
            try
            {
                return new ResultModel<List<User>>
                {
                    Success = true,
                    Model = _userDL.GetUsers()
                };
            }
            catch (Exception ex)
            {
                return new ResultModel<List<User>>
                {
                    Success = false,
                    ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה"
                };
            }

        }

        ResultModel<User> IUserBL.GetUser(string id)
        {
            var error = _getUserValidator.GetValidat(id);

            if (error != null)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    ErrorMessage = error
                };
            }
            var user = _userDL.GetUser(id);

            try
            {
                return new ResultModel<User>
                {
                    Success = user != null,
                    Model = user,
                    ErrorMessage = (user != null) ? "" : "eror"
                };
            }
            catch (Exception ex)
            {
                return new ResultModel<User>
                {
                    Success = false,
                    ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה"
                };
            }
        }

        ResultModel<object> IUserBL.AddUser(User user)
        {
            var error = _addUserValidator.Validat(user);

            if (error != null)
            {
                return new ResultModel<object>
                {
                    Success = false,
                    ErrorMessage = error
                };
            }

            try
            {
                _userDL.AddUser(user);
                return new ResultModel<object> { Success = true };
            }
            catch (Exception)
            {
                return new ResultModel<object> { Success = false, ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה" };
            }

        }
    }
}
