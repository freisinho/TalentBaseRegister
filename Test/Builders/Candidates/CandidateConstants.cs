using Test.Builders.Addresses;
using Test.Builders.Banks;
using Test.Builders.Emails;
using Test.Builders.Phones;
using Test.Builders.Skypes;
using TesteEasy.Models.Entities;

namespace Test.Builders.Candidates
{
    public partial class CandidateBuilder
    {
        private static readonly Address Address = new AddressBuilder().DataBuilder().Build();
        private static readonly Email Email = new EmailBuilder().DataBuilder().Build();
        private static readonly Phone Phone = new PhoneBuilder().DataBuilder().Build();
        private static readonly Bank Bank = new BankBuilder().DataBuilder().Build();
        private static readonly Skype Skype = new SkypeBuilder().DataBuilder().Build();

        private const string Name = "Nome Teste";
        private const string CrudLink = "git";
        private const string OtherKnowledge = "Other";
        private const string Linkedin = "cainã frei";
        private const string Portifolio = "---";
    }
}
