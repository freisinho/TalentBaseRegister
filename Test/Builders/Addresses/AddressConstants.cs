using Test.Builders.Cities;
using TesteEasy.Models.Entities;

namespace Test.Builders.Addresses
{
    public partial class AddressBuilder
    {
        private static readonly City City = new CityBuilder().DataBuilder().Build();
    }
}
