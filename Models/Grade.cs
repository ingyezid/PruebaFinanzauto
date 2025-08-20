using System.ComponentModel.DataAnnotations;

namespace PruebaFinanzauto.Models
{
    public class Grade
    {
        [Key]
       public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }

        public  virtual Course Course { get; set; }

        [Required]
        public decimal Score { get; set; }

    }
}
