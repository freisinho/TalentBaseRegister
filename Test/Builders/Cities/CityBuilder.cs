using TesteEasy.Models.Entities;

namespace Test.Builders.Cities
{
    public partial class CityBuilder
    {
        public City City { get; set; }

        public CityBuilder()
        {
            City = new City();
        }

        public CityBuilder DataBuilder(string name = null, State state = null)
        {
            City.Name = name ?? Name;
            City.State = state ?? State;

            return this;
        }

        public City Build()
        {
            return City;
        }
    }
}
