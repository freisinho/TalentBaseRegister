using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEasy.Models.Entities
{
    [Table("CdTwEmails")]
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(160)]
        public string Address { get; set; }
    }
}