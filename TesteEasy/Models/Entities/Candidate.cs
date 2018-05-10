using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteEasy.Models.Enums;
using TesteEasy.Models.Relations;

namespace TesteEasy.Models.Entities
{
    [Table("CdTwCandidates")]
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        public virtual Email Email { get; set; }

        [Required, MaxLength(160)]
        public string Name { get; set; }

        public virtual Skype Skype { get; set; }

        public virtual Phone Phone { get; set; }

        [MaxLength(160)]
        public string Linkedin { get; set; }

        public virtual Address Address { get; set; }

        public virtual Bank Bank { get; set; }

        public string Portifolio { get; set; }

        public string OtherKnowledge { get; set; }
        
        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string CrudLink { get; set; }

        [Required]
        public TimeToWorkOptions TimeToWork { get; set; }

        [Required]
        public WillingnessOptions Willingness { get; set; }

        public AccountType AccountType { get; set; }

        [ForeignKey("CandidateId")]
        public virtual ICollection<CandidateKnowledge> CandidateKnowledge { get; set; }

    }
}