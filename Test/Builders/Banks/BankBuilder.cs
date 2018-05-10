using TesteEasy.Models.Entities;

namespace Test.Builders.Banks
{
    public partial class BankBuilder
    {
        public Bank Bank { get; set; }

        public BankBuilder()
        {
            Bank = new Bank();
        }

        public BankBuilder DataBuilder(string account = null, string agency = null, string cpf = null, string name = null)
        {
            Bank.Account = account ?? Account;
            Bank.Agency = agency ?? Agency;
            Bank.Cpf = cpf ?? Cpf;
            Bank.Name = name ?? Name;

            return this;
        }

        public Bank Build()
        {
            return Bank;
        }
    }
}
