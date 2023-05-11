using CovidSystem.DL.Interfaces;
using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Validation
{
    public class IsPatientExistValidation : IIsPatientExistValidation
    {
        private readonly IPatientDL _patientDL;

        public IsPatientExistValidation(IPatientDL patientDL)
        {
            _patientDL = patientDL;
        }

        public void IsPatientExistValid(string id)
        {
            if (_patientDL.IsPatientExist(id))
            {
                throw new Exception("משתמש בעל תז זאת כבר חלה בקורונה ואי אפשר לחלות פעמיים");
            }
        }

    }
}
