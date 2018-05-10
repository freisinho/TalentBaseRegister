using System.Linq;
using TesteEasy.Models;
using TesteEasy.Models.Entities;

namespace TesteEasy.Migrations.SeedData
{
    public class TechnologiesCreator
    {
        public TechnologiesCreator(CandidateDbSet context)
        {
            Context = context;
        }

        public CandidateDbSet Context { get; }

        public void Create() => CreateTechnologies();

        public void CreateIfNotExist(string name)
        {
            var exist = Context.Technologies.FirstOrDefault(item => item.Name == name);

            if (exist == null)
            {
                Context.Technologies.Add(new Technology
                {
                    Name = name
                });
            }
        }


        private void CreateTechnologies()
        {
            CreateIfNotExist("Ionic");
            CreateIfNotExist("Android");
            CreateIfNotExist("IOS");
            CreateIfNotExist("HTML");
            CreateIfNotExist("CSS");
            CreateIfNotExist("Bootstrap");
            CreateIfNotExist("Jquery");
            CreateIfNotExist("AngularJs");
            CreateIfNotExist("Java");
            CreateIfNotExist("Asp.Net MVC");
            CreateIfNotExist("C");
            CreateIfNotExist("C++");
            CreateIfNotExist("Cake");
            CreateIfNotExist("Django");
            CreateIfNotExist("Magento");
            CreateIfNotExist("PHP");
            CreateIfNotExist("Vue");
            CreateIfNotExist("Wordpress");
            CreateIfNotExist("Phyton");
            CreateIfNotExist("Ruby");
            CreateIfNotExist("SQL Server");
            CreateIfNotExist("My SQL");
            CreateIfNotExist("Salesforce");
            CreateIfNotExist("Photoshop");
            CreateIfNotExist("Illustrator");
            CreateIfNotExist("SEO");

            Context.SaveChanges();
        }
    }
}
