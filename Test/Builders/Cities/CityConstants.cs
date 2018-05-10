using Test.Builders.States;
using TesteEasy.Models.Entities;

namespace Test.Builders.Cities
{
    public partial class CityBuilder
    {
        private const string Name = "Caldas";

        private static readonly State State = new StateBuilder().DataBuilder().Build();
    }

}
