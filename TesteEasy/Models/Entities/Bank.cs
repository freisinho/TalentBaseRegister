using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEasy.Models.Entities
{
    [Table("CdTwBanks")]
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(160)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Cpf { get; set; }

        [MaxLength(12)]
        public string Agency { get; set; }

        [MaxLength(120)]
        public string Account { get; set; }
    }
}