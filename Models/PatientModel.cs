using System.ComponentModel.DataAnnotations.Schema;

namespace CovidSystem.Models
{
    public class PatientModel
    {
        public string UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
