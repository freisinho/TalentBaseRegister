using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Builders.Candidates;
using TesteEasy.Controllers;
using TesteEasy.Models;

namespace Test
{
    [TestClass]
    public class CandidateControllerTest
    {
        public readonly CandidateDbSet Context = new CandidateDbSet();

        [TestMethod]
        public async Task ShouldCreateACandidateAsync()
        {
            var controller = new CandidateController();

            var candidate = new CandidateBuilder().DataBuilder().Build();
            
            var result = await controller.PostCandidate(candidate);

            var candidateCreated = await Context.Candidates.FindAsync(result);

            Assert.IsNotNull(candidateCreated);

            Assert.AreEqual("Nome Teste", candidateCreated.Name);

        }
    }
}
