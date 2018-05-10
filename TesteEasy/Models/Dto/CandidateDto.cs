using System.Collections.Generic;
using TesteEasy.Models.Entities;
using TesteEasy.Models.Enums;

namespace TesteEasy.Models.Dto
{
    public class CandidateDto
    {
        public int Id { get; set; }

        public Email Email { get; set; }

        public string Name { get; set; }

        public Skype Skype { get; set; }

        public Phone Phone { get; set; }

        public string Linkedin { get; set; }

        public Address Address { get; set; }

        public Bank Bank { get; set; }

        public string Portifolio { get; set; }

        public decimal Salary { get; set; }

        public string CrudLink { get; set; }

        public string OtherKnowledge { get; set; }

        public TimeToWorkOptions TimeToWork { get; set; }

        public WillingnessOptions Willingness { get; set; }

        public AccountType AccountType { get; set; }

        public ICollection<CandidateKnowledgeDto> CandidateKnowledge { get; set; }
    }
}