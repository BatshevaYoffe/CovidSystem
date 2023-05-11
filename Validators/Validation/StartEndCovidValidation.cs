using CovidSystem.DL.Interfaces;
using CovidSystem.Models;
using CovidSystem.Validators.Validation.Interfaces;
using System;

namespace CovidSystem.Validators.Validation
{
    public class StartEndCovidValidation: IStartEndCovidValidation
    {
        private readonly IUserDL _userDL;

        public StartEndCovidValidation(IUserDL userDL)
        {
            _userDL = userDL;
        }

        public bool IsValidDate(DateTime date)
        {
            // בודקים שהתאריך תקין
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
            {
                return false;
            }

            // בודקים שהתאריך עדיין לא עבר
            if (date >= DateTime.Today)
            {
                return false;
            }

            return true;
        }


        public void IsStartEndCovidValid(PatientModel patient)
        {
            DateTime date1=patient.Start;
            DateTime date2=patient.End;

            if (IsValidDate(date1)){
                if (IsValidDate(date2))
                {
                    DateTime birthdate = _userDL.UserBirthDate(patient.UserId);
                    if (birthdate < date1)
                    {
                        if (date1 > date2)
                        {
                            throw new Exception("התאריך התחלת קורונה היה לפני התאריך הסוף");
                        }
                    }
                    else
                    {
                        throw new Exception("תאריך לידה לפני תאריך התחלת מחלת הקורונה");
                    }
                }
                else
                {
                    throw new Exception("תאריך סוף קורונה לא תקין");
                }
            }
            else
            {
                throw new Exception("תאריך תחילת קורונה לא תקין");
            }
        }
        

    }
}
