using CovidSystem.Validators.Validation.Interfaces;

namespace CovidSystem.Validators.Validation
{
    public class IdNumberValidation : IIdNumberValidation
    {
        public void IsIdNumberValid(string id)
        {
            id = id.Trim();
            if (id.Length > 9 || !int.TryParse(id, out int idNum))
            {
                throw new Exception("id is not validate");
            }
            id = id.Length < 9 ? ("00000000" + id).Substring(id.Length) : id;
            int sum = 0;
            for (int i = 0; i < id.Length; i++)
            {
                int digit = int.Parse(id[i].ToString());
                int step = digit * ((i % 2) + 1);
                sum += step > 9 ? step - 9 : step;
            }
            if (sum % 10 != 0)
            {
                throw new Exception("id is not validate");
            }
        }
    }
}
