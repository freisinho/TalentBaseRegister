using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteEasy.Models.Relations;

namespace TesteEasy.Models.Entities
{
    [Table("CdTrTechnologies")]
    public class Technology
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("TechnologyId")]
        public virtual ICollection<CandidateKnowledge> CandidateKnowledge { get; set; }

    }
}