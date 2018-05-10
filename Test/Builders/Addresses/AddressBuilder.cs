using TesteEasy.Models.Entities;

namespace Test.Builders.Addresses
{
    public partial class AddressBuilder
    {
        public Address Address { get; set; }

        public AddressBuilder()
        {
            Address = new Address();
        }

        public AddressBuilder DataBuilder( City city = null)
        {
            Address.City = city ?? City;

            return this;
        }

        public Address Build()
        {
            return Address;
        }
    }
}
