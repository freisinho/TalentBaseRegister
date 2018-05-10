using System.Data.Entity;
using TesteEasy.Models.Entities;
using TesteEasy.Models.Relations;

namespace TesteEasy.Models
{
    public class CandidateDbSet : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Skype> Skypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<CandidateKnowledge> CandidateKnowledges { get; set; }
    }
}