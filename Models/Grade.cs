using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaFinanzauto.Models
{
    public class Grade
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        [JsonIgnore]
        public virtual Student? Student { get; set; }

        public Guid CourseId { get; set; }

        [JsonIgnore]
        public virtual Course? Course { get; set; }

        [Required]
        public decimal Score { get; set; }

    }
}
