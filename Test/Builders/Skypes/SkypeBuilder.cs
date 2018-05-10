using TesteEasy.Models.Entities;

namespace Test.Builders.Skypes
{
    public partial class SkypeBuilder
    {
        public Skype Skype { get; set; }

        public SkypeBuilder()
        {
            Skype = new Skype();
        }

        public SkypeBuilder DataBuilder(string name = null)
        {

            Skype.Name = name ?? Name;

            return this;
        }

        public Skype Build()
        {
            return Skype;
        }
    }
}
