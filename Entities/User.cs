using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidSystem.Entities
{
    public class User
    {
        [Key]
        public string IdNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        //public List<Vaccination> MyVacctination { get; set; }
    }
}
