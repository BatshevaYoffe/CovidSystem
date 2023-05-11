using CovidSystem.BL.Interfaces;
using CovidSystem.DL;
using CovidSystem.DL.Interfaces;
using CovidSystem.Entities;
using CovidSystem.Models;
using CovidSystem.Validators.Vaccination.Interfaces;

namespace CovidSystem.BL
{
    public class VaccinationBL : IVaccinationBL
    {
        private readonly IVaccinationDL _vaccinationDL;
        private readonly IAddVaccinationValidator _addVaccinationValidator;
        private readonly IGetVaccinationValidator _getVaccinationValidator;


        public VaccinationBL(IVaccinationDL vaccinationDL, IAddVaccinationValidator addVaccinationValidator, IGetVaccinationValidator getVaccinationValidator)
        {
            _vaccinationDL = vaccinationDL;
            _addVaccinationValidator = addVaccinationValidator;
            _getVaccinationValidator = getVaccinationValidator;

        }

        ResultModel<object> IVaccinationBL.AddVaccination(Vaccination vaccination)
        {

            var error = _addVaccinationValidator.AddVaccinationValidat(vaccination);

            if (error != null)
            {
                return new ResultModel<object>
                {
                    Success = false,
                    ErrorMessage = error
                };
            }

            //בדיקה האם התז של האדם שהתחסן קיים כבר במערכת ואם לא לנסות להוסיף


            try
            {
                _vaccinationDL.AddVaccination(vaccination);
                return new ResultModel<object> { Success = true };
            }
            catch (Exception)
            {
                return new ResultModel<object> { Success = false, ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה" };
            }

        }

        ResultModel<Vaccination> IVaccinationBL.GetUserVaccination(string userId)
        {
            var error = _getVaccinationValidator.GetVaccinationValidat(userId);

            if (error != null)
            {
                return new ResultModel<Vaccination>
                {
                    Success = false,
                    ErrorMessage = error
                };
            }
            var vacctination = _vaccinationDL.GetUserVaccination(userId);

            try
            {
                return new ResultModel<Vaccination>
                {
                    Success = vacctination != null,
                    Model = vacctination,
                    ErrorMessage = (vacctination != null) ? "" : "eror"
                };
            }
            catch (Exception)
            {
                return new ResultModel<Vaccination>
                {
                    Success = false,
                    ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה"
                };
            }
        }

        ResultModel<List<Vaccination>> IVaccinationBL.GetVaccinations()
        {
            try
            {
                return new ResultModel<List<Vaccination>>
                {
                    Success = true,
                    Model = _vaccinationDL.GetVaccinations()
                };
            }
            catch (Exception ex)
            {
                return new ResultModel<List<Vaccination>>
                {
                    Success = false,
                    ErrorMessage = "ארעה שגיאה , הפעולה לא בוצעה"
                };
            }
        }
    }
}
