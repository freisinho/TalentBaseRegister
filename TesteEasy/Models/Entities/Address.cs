using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEasy.Models.Entities
{
    [Table("CdTwAddresses")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public City City { get; set; }
    }
}