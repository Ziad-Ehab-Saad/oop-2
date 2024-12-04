namespace BankSystem
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string Name = "Unnamed Account", double Balance = 0.0)
        {
            this.Name = Name;
            this.Balance = Balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool  Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

       
        public static Account operator + (Account lhs , Account rhs)
        {
        
            return new Account("Unamed Account",lhs.Balance + rhs.Balance);

        }


        public override string ToString()
        {
            return $"Name : {Name} , Balance : {Balance}" ;
        }
    }
}
