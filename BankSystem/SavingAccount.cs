namespace BankSystem
{

    
        class SavingAccount:Account {
            public double interstRate{ get; set; }


        public SavingAccount(string Name ="none" , double Balance=0.0, double interstrate=0.0):base(Name,Balance)
        {
            interstRate= interstrate;
        }

        public override string ToString()
        {
            return $"{ base.ToString()} , InterstRate : {interstRate}" ;
        }



    }
    }
