using CovidSystem.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidSystem.Entities
{
    public class Vaccination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string VaccinationId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Manufactor { get; set; }
       // public User User { get; set; }
    }
}
