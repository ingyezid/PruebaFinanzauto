using System.ComponentModel.DataAnnotations;

namespace PruebaFinanzauto.Models
{
    public class Teacher
    {        
            [Key]
            public Guid Id { get; set; }

            [Required]
            [MaxLength(10)]
            public string Identification { get; set; }

            [Required]
            [MaxLength(50)]
            public string LastName { get; set; }

            [Required]
            [MaxLength(50)]
            public string FirstName { get; set; }


            public virtual ICollection<Course> Courses { get; set; }
    }
}
