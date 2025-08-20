using System.ComponentModel.DataAnnotations;

namespace PruebaFinanzauto.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public int Credits { get; set; }

        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

    }
}
