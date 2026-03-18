using System;
using System.Collections.Generic;

namespace BankCardPIN
{
    class Bank
    {
        #region MAIN 
        static void Main(string[] args)
        {
            bool isPinValid = false;
            BankCard myCard = null;

            do
            {
                Console.WriteLine("Enter your new 4-digit PIN:");
                int userChoice = int.Parse(Console.ReadLine());

                myCard = new BankCard(userChoice);

                if (myCard.Pin != 0)
                {
                    isPinValid = true;
                    Console.WriteLine("Success! Card Created.");
                }
                else
                {
                    Console.WriteLine("Try again...");
                }

            } while (!isPinValid);

            Console.WriteLine("Your final verified PIN is: " + myCard.Pin);

            myCard.Deposit(50);
            myCard.Withdraw(30);
            Console.WriteLine("End of day balance: " + myCard.Balance);
            myCard.PrintHistory();
        }
        #endregion
    }

    class BankCard
    {
        #region Private Fields
        private int _pin;
        private int _balance;

        private List<string> _transactionHistory = new List<string>();
        #endregion

        #region Constructor
        public BankCard(int startingPin)
        {
            Pin = startingPin;
            _balance = 100;

            _transactionHistory.Add("Card opened with 100 Euro starting balance.");
        }
        #endregion

        #region Properties
        public int Pin
        {
            get { return _pin; }
            set
            {
                if (value >= 1000 && value <= 9999)
                {
                    _pin = value;
                }
                else
                {
                    Console.WriteLine("Invalid PIN! Must be 4 digits.");
                }
            }
        }


        // ------------------------------------------------------------------------------//


        public int Balance
        {
            get { return _balance; }
        }
        #endregion

        #region Withdraw Method
        public void Withdraw(int amount)
        {
            if (amount <= _balance)
            {
                _balance -= amount;

                _transactionHistory.Add($"Withdrew {amount} Euros. Remaining: {_balance}");

                Console.WriteLine($"Withdrew {amount} Euros.");
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
        #endregion

        #region Deposit Method
        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                _balance += amount;

                _transactionHistory.Add($"Deposited {amount} Euros. New Balance: {_balance}");

                Console.WriteLine($"Deposited {amount} Euros.");
            }
        }
        #endregion

        #region History Method
        public void PrintHistory()
        {
            Console.WriteLine("\n--- TRANSACTION HISTORY ---");

            foreach (string note in _transactionHistory)
            {
                Console.WriteLine(note);
            }

            Console.WriteLine("---------------------------\n");
        }
    }
}
    #endregion

