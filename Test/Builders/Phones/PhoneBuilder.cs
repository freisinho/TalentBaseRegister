using TesteEasy.Models.Entities;

namespace Test.Builders.Phones
{
    public partial class PhoneBuilder
    {
        public Phone Phone { get; set; }

        public PhoneBuilder()
        {
            Phone = new Phone();
        }

        public PhoneBuilder DataBuilder(string number = null)
        {

            Phone.Number = number ?? Number;

            return this;
        }

        public Phone Build()
        {
            return Phone;
        }
    }
}
