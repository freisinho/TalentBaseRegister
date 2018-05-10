using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEasy.Models.Entities
{
    [Table("CdTwPhones")]
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(160)]
        public string Number { get; set; }
    }
}