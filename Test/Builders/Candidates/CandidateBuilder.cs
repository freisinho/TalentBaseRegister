using TesteEasy.Models.Entities;
using TesteEasy.Models.Enums;

namespace Test.Builders.Candidates
{
    public partial class CandidateBuilder
    {
        public Candidate Candidate { get; set; }

        public CandidateBuilder()
        {
            Candidate = new Candidate();
        }



        public CandidateBuilder DataBuilder(string name = null, string crud = null, string linkedin = null,
                                            string other = null, string portifolio = null,
                                            decimal salary = 30m, Address address = null, Email email = null,
                                             Phone phone = null, Bank bank = null, Skype skype = null)
        {
            Candidate.Address = address ?? Address;
            Candidate.Email = email ?? Email;
            Candidate.Phone = phone ?? Phone;
            Candidate.Bank = bank ?? Bank;
            Candidate.Skype = skype ?? Skype;
            Candidate.Name = name ?? Name;
            Candidate.AccountType = AccountType.Savings;
            Candidate.CrudLink = crud ?? CrudLink;
            Candidate.Linkedin = linkedin ?? Linkedin;
            Candidate.OtherKnowledge = other ?? OtherKnowledge;
            Candidate.Portifolio = portifolio ?? Portifolio;
            Candidate.Salary = salary;
            Candidate.TimeToWork = TimeToWorkOptions.Afternoon;
            Candidate.Willingness = WillingnessOptions.FourToSix;

            return this;
        }

        public Candidate Build()
        {
            return Candidate;
        }
    }
}
