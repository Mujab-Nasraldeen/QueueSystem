using System.ComponentModel.DataAnnotations;

namespace QueueSystem.Models
{
    public class Doctor
    {
        //[Key]
        public Guid Id { get; set; }

        [Required, MaxLength(250)]
        public string FullName { get; set; }

        [Required, MaxLength(100)]
        public string Specification { get; set; }

        [Required, MaxLength(15)]
        public string Phone { get; set; }
    }
}
