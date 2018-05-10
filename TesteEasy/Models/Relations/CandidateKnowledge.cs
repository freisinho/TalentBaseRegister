using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteEasy.Models.Entities;

namespace TesteEasy.Models.Relations
{
    [Table("CdTwCandidateKnowledge")]
    public class CandidateKnowledge
    {
        public int Id { get; set; }

        [ForeignKey("TechnologyId")]
        public virtual Technology Technology { get; set; }

        [Key, Column(Order = 0)]
        public int TechnologyId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual Candidate Candidate { get; set; }

        [Key, Column(Order = 1)]
        public int CandidateId { get; set; }

        public int Evaluation { get; set; }
    }
}