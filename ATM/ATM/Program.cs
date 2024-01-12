using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ATM
{
    public class program
    {
        static void Main(string[] args)
        {
            //XML File Path
            string path = @"C:\Users\aaijaz\source\repos\ATM\account_deatils.xml";

            // SERILIZATION
            void serilization(List<Customer> customers)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, customers);

                }
            }

            // DESERILIZATION
            List<Customer> deserilization()
            {
                List<Customer> desCust = new List<Customer>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
                using (StreamReader reader = new StreamReader(path))
                {
                    desCust = (List<Customer>)serializer.Deserialize(reader);
                }
                return desCust;
            }

            void welcome()
            {
                Console.WriteLine("################# Welcome to Alfa ATM ######################");
                Console.WriteLine("\nPlease Select any option below to continue...");
                Console.WriteLine("1. Existing User");
                Console.WriteLine("2. New User");
                int mainOption = int.Parse(Console.ReadLine());
                if (mainOption == 1)
                {
                    login();
                }
                else if (mainOption == 2)
                {
                    newUser();
                }
            }

            welcome();

            void newUser()
            {
                Console.WriteLine("Please enter name: ");
                string newName = Console.ReadLine();
                Console.WriteLine("Please enter account number: ");
                string newAcctNum = Console.ReadLine();
                
                List<Customer> customer = deserilization();
                foreach( Customer cust in customer)
                {
                    if(newAcctNum == cust.accountNumber)
                    {
                        Console.WriteLine("This account number already exists. Try another one.");
                        Console.WriteLine("Please enter account number: ");
                        newAcctNum = Console.ReadLine();

                    }
                }

                Console.WriteLine("Please enter password: ");
                int newPass = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter an amount: ");
                double newBalance = double.Parse(Console.ReadLine());

                Customer newCustomer = new Customer();
                newCustomer.accountNumber = newAcctNum;
                newCustomer.password = newPass;
                newCustomer.name = newName;
                newCustomer.balance = newBalance;

                customer.Add(newCustomer);
                serilization(customer);

                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Account created successfully!\n\n");
                login();

            }

            void login()
            {
                Console.WriteLine("\t\tLogin");
                Console.WriteLine("Enter your account number: ");
                String acctNum = Console.ReadLine();

                bool isAccount = false;
                List<Customer> desCustomer = deserilization();
                foreach (Customer arg in desCustomer)
                {
                    if (acctNum == arg.accountNumber)
                    {
                        isAccount = true;
                        Console.WriteLine("Enter your password: ");
                        int pass = int.Parse(Console.ReadLine());
                        if (pass == arg.password)
                        {
                            Console.WriteLine("Welcome " + arg.name);
                            int option = 0;
                            do
                            {
                                selectOptions();

                                option = int.Parse(Console.ReadLine());

                                if (option == 1)
                                {
                                    deposit(arg);
                                }
                                else if (option == 2)
                                {
                                    withdraw(arg);
                                }
                                else if (option == 3)
                                {
                                    balance(arg);
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
                            Thread.Sleep(2000);
                            Console.Clear();
                            welcome();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password");

                        }

                    }
                    serilization(desCustomer);
                }
                if (!isAccount)
                {
                    Console.WriteLine("\nAccount not found!\n");
                    Console.WriteLine("Please select any option below to process: ");
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("2. Create New Account");
                    Console.WriteLine("3. Exit");
                    int select = int.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        login();
                    }
                    else if (select == 2)
                    {
                        newUser();
                    }
                    else
                    {
                        return;
                    }
                }
            }

            void selectOptions()
            {
                Console.WriteLine("\nPlease select any option to process ...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(Customer currentUsers)
            {
                Console.WriteLine("Please enter amount to deposit: ");
                double deposited = double.Parse(Console.ReadLine());
                currentUsers.balance = currentUsers.balance+deposited;
                Console.WriteLine("You deposited successfully!");
                Console.WriteLine("Your new balance is " + currentUsers.balance);
            }

            void withdraw(Customer currentUsers)
            {
                Console.WriteLine("Please enter an amount to withdraw: ");
                double withdrawal = double.Parse(Console.ReadLine());

                if (currentUsers.balance < withdrawal)
                {
                    Console.WriteLine("Sorry, you have insufficient balance in account!");
                }
                else
                {
                    currentUsers.balance = currentUsers.balance - withdrawal;
                    Console.WriteLine("You have withdrawn an amount successfully!");
                    Console.WriteLine("Your new balance is " + currentUsers.balance);
                }
            }

            void balance(Customer currentUsers)
            {
                Console.WriteLine("Current balance: " + currentUsers.balance);
            }

        }
    }
}
