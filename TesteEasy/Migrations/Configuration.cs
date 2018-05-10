using TesteEasy.Migrations.SeedData;

namespace TesteEasy.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CandidateDbSet>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CandidateDbSet context)
        {
            var technologyCreator = new TechnologiesCreator(context);
            var candidateCreator = new CandidatesCreator(context);

            technologyCreator.Create();
            candidateCreator.Create();
        }
    }
}
