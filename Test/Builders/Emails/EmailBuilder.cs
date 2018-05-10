using TesteEasy.Models.Entities;

namespace Test.Builders.Emails
{
    public partial class EmailBuilder
    {
        public Email Email { get; set; }

        public EmailBuilder()
        {
            Email = new Email();
        }

        public EmailBuilder DataBuilder(string address = null)
        {

            Email.Address = address ?? Address;

            return this;
        }

        public Email Build()
        {
            return Email;
        }
    }
}
