using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CovidSystem.Entities
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }//להחליף כך שלא המשתמש בוחר
        [ForeignKey("User")]
        public string UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
       // public User User { get; set; }

    }
}
