using System.Data;

namespace BankSystem
{
    class CheckingAccount : Account
    {

        const double fee = 1.5;

       public CheckingAccount(string Name = "Unnamed Account", double Balance = 0) : base(Name, Balance)
        {
        }

        public override bool Withdraw(double amount)
        {
            Balance -= fee;
            if (base.Withdraw(amount))
            {
                return true;
            }
            else
            {
                Balance += fee;
                return false;
            }



        }


        public override string ToString()
        {
            return base.ToString();
        }

    }
}
