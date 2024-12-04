using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Security.Cryptography;

namespace BankSystem
{
    class TrustAccount : SavingAccount
    {
        const int bouns = 50;
        int count = 0;
        List<DateTime> dates;
        DateTime dateAndTime = DateTime.Now.Date;


        public TrustAccount(string Name = "none", double Balance = 0, double interstrate = 0) : base(Name, Balance, interstrate)
        {
            dates = new List<DateTime>();
        }

        public override bool Deposit(double amount)
        {
            bool flag = base.Deposit(amount);
            if (flag && amount >= 5000)
            {
                Balance += bouns;
                return true;

            }

            return false;
        }


        public override bool Withdraw(double amount)
        {
            
            double maxAllowed = Balance * 0.2;
            if (amount > maxAllowed)
            {
                Console.WriteLine("Cannot withdraw: amount exceeds 20% of the balance.");
                return false;
            }
           DateTime currentTransactionDate = DateTime.Now.Date;

            if (count == 0)
            {
                base.Withdraw(amount);
                dates.Clear(); 
                dates.Add(currentTransactionDate); 
                count++;
                Console.WriteLine("First withdrawal of the year successful.");
                return true;
            }

            DateTime yearBoundary = dates[0].AddYears(1);
            if (currentTransactionDate <= yearBoundary)
            {
                if (count < 3) 
                {
                    base.Withdraw(amount);
                    count++;
                    Console.WriteLine($"Withdrawal successful. {3 - count} withdrawals remaining this year.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Cannot withdraw: the limit of 3 withdrawals is reached.");
                    return false;
                }
            }
            else
            {
                count = 0;
                dates.Clear();
                dates.Add(currentTransactionDate);
                base.Withdraw(amount);
                count++;
                Console.WriteLine("New year: Withdrawal successful .");
                return true;
            }
        }



        public void printList()
        {
            for (int i = 0; i < dates.Count; i++)
            {
                Console.WriteLine(dates[i]);
            }
        }


        public override string ToString()
        {
            return base.ToString();
        }

    }
}
