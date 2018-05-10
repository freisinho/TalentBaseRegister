using System;
using System.Collections.Generic;
using System.Linq;
using TesteEasy.Models;
using TesteEasy.Models.Entities;
using TesteEasy.Models.Enums;
using TesteEasy.Models.Relations;

namespace TesteEasy.Migrations.SeedData
{
    public class CandidatesCreator
    {
        public CandidatesCreator(CandidateDbSet context)
        {
            Context = context;
        }

        public CandidateDbSet Context { get; }

        public void Create()
        {
            CreateCandidates();
        }

        public void CreateIfNotExist(string name)
        {
            var exist = Context.Candidates.FirstOrDefault(item => item.Name == name);

            if (exist == null)
            {
                Context.Candidates.Add(new Candidate
                {
                    Name = name,
                    Address = new Address
                    {
                        City = new City
                        {
                            Name = "Caldas",
                            State = new State
                            {
                                Name = "Minas Gerais"
                            }
                        },

                    },
                    Bank = new Bank
                    {
                        Account = "1811-2",
                        Agency = "1704-3",
                        Cpf = "112.309.116-18",
                        Name = "Banco do Brasil"
                    },
                    CrudLink = "https://github.com/freisinho",
                    Email = new Email
                    {
                        Address = "caina.frei@gmail.com"
                    },
                    Linkedin = "https://www.linkedin.com/in/cainã-frei-3717b912a",
                    Phone = new Phone
                    {
                        Number = "55 (35) 98423-2105"
                    },
                    Portifolio = "---",
                    Salary = 30,
                    Skype = new Skype
                    {
                        Name = "Cainã Frei - caina.frei@hotmail.com"
                    },
                    TimeToWork = TimeToWorkOptions.Business,
                    Willingness = WillingnessOptions.SixToEight,
                    AccountType = AccountType.Chain,
                    OtherKnowledge = "Scrum 3",
                    CandidateKnowledge = FillsCandidateKnowledge()
                });
            }
        }

        private ICollection<CandidateKnowledge> FillsCandidateKnowledge()
        {
            var tecnologies = Context.Technologies;

            var rand = new Random();

            var knowledges = new List<CandidateKnowledge>();

            foreach (var aux in tecnologies)
            {
                knowledges.Add(new CandidateKnowledge
                {
                    TechnologyId = aux.Id,
                    Evaluation = rand.Next(0,5)
                });
            }

            return knowledges;
        }

        private void CreateCandidates()
        {
            CreateIfNotExist("Cainã dos Reis Frei");

            Context.SaveChanges();
        }
    }
}
