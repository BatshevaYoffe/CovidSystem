using System.ComponentModel.DataAnnotations.Schema;

namespace CovidSystem.Models
{
    public class VaccinationModel
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Manufactor { get; set; }
    }
}
