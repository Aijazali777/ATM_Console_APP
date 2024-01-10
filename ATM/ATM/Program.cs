using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class cardHolder
    {
        static void Main(string[] args)
        {
            void selectOptions()
            {
                Console.WriteLine("Please select any option to process ...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUsers)
            {
                Console.WriteLine("Please enter amount to deposit: ");
                double deposited = double.Parse(Console.ReadLine());
                currentUsers.setBalance(currentUsers.getBalance()+deposited);
                Console.WriteLine("You deposited successfully!");
                Console.WriteLine("Your new balance is " + currentUsers.getBalance());
            }

            void withdraw(cardHolder currentUsers)
            {
                Console.WriteLine("Please enter an amount to withdraw: ");
                double withdrawal = double.Parse(Console.ReadLine());

                if(currentUsers.getBalance() < withdrawal)
                {
                    Console.WriteLine("Sorry, you have insufficient balance in account!");
                }
                else
                {
                    currentUsers.setBalance(currentUsers.getBalance() - withdrawal);
                    Console.WriteLine("You have withdrawn an amount successfully!");
                    Console.WriteLine("Your new balance is " + currentUsers.getBalance());
                }
            }

            void balance(cardHolder currentUsers)
            {
                Console.WriteLine("Current balance: " + currentUsers.getBalance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("1001", 1231, "John", "Harding", 78241.03));
            cardHolders.Add(new cardHolder("1002", 1232, "Smith", "Dawn", 19010.92));
            cardHolders.Add(new cardHolder("1003", 1233, "Mathew", "Wade", 56394.00));

            Console.WriteLine("Welcome to Alfa ATM!");
            Console.WriteLine("Please insert your debit card: ");
            String debitCardNum = "";
            cardHolder currentUser;

            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if(currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Account not found, please try again!");
                    }
                }
                catch
                {
                    Console.WriteLine("Account not found, please try again!");
                }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password, please try again!");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect password, please try again!");
                }
            }

            Console.WriteLine("Welcome " + currentUser.getFName()+" :)");
            int option = 0;
            do
            {
                selectOptions();
               
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    deposit(currentUser);
                }
                else if (option == 2)
                {
                    withdraw(currentUser);
                }
                else if (option == 3)
                {
                    balance(currentUser);
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    option = 0;
                }
            }
            while (option != 4);
            Console.WriteLine("Thank you! Have a nice day :)");
        }

        string cardNum;
        int pin;
        String firstName;
        String lastName;
        double balance;

        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance =  balance;
        }

        public String getNum()
        {
            return cardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public String getFName()
        {
            return firstName;
        }

        public String getLName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFName(string newFristName)
        {
            firstName = newFristName;
        }

        public void setLName(string newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }
    }
}
