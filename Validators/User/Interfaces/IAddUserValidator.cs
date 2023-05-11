using CovidSystem.Entities;


namespace CovidSystem.Validators.User.Interfaces
{
    public interface IAddUserValidator
    {
        string Validat(CovidSystem.Entities.User user);
    }
}
