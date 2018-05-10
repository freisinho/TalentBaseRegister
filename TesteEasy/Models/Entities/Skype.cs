using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEasy.Models.Entities
{
    [Table("CdTwSkypes")]
    public class Skype
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(160)]
        public string Name { get; set; }
    }
}