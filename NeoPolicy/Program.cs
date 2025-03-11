using NeoPolicy.Interfaces;
using NeoPolicy.Models;
using NeoPolicy.Repositories;

namespace NeoPolicy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id;
            Console.WriteLine("Welcome to NeoPolicy");

        YouHaveAccount:
            Console.WriteLine("\n Do you have an account? \nPress 1:Yes\nPress 2: No\n Press 3 : Terminate program");
            bool isAccountOption = int.TryParse(Console.ReadLine(), out int accountOption);

            if (!isAccountOption || accountOption>3 ||accountOption<1)
            {
                Console.WriteLine("\n Invalid input \n Try again");
                goto YouHaveAccount;
            }
            IloginandRegister loginAndRegister = new LoginandRegister();
        LoginForm:
            if (accountOption==1)
            {
                Console.WriteLine("\nLogin Form");
                Console.WriteLine("Id :");
                bool isId = int.TryParse(Console.ReadLine(), out id);
                if (!isId)
                {
                InnerOption:
                    Console.WriteLine("\n Invalid input");
                    Console.WriteLine("Press 1 :Try again");
                    Console.WriteLine("Press 2 : Go to start page");
                    bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                    if (!isInnerOption || innterOption > 2 || innterOption < 1) {
                        goto InnerOption;
                    }
                    if (innterOption==1)
                    {
                        goto LoginForm;
                    }
                    if (innterOption == 2)
                    {
                        goto YouHaveAccount;
                    }
                 
                }
                Console.WriteLine("Password:");
                string password = Console.ReadLine();
                bool isLoggedIn = loginAndRegister.Loggin(id, password);
                if (isLoggedIn)
                {
                    Console.WriteLine("\n Loggedin successfully");
                    Menu:
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("Press 1 : Add policy");
                    Console.WriteLine("Press 2 : View all policy");
                    Console.WriteLine("Press 3 : Search policy by Id");
                    Console.WriteLine("Press 4 : Updated policy");
                    Console.WriteLine("Press 5 : Delete policy");
                    Console.WriteLine("Press 6 : View active policy");
                    Console.WriteLine("Press any key to exit/Loggout");

                    bool isMenuOption = int.TryParse(Console.ReadLine(), out int menuOption);
                    if (isMenuOption)
                    {
                        Ipolicy policy = new PolicyWork();
                        switch (menuOption)
                        {
                            case 1:
                                {
                                    AddPolicy:
                                    Console.WriteLine("\nAdd policy\nPolicy Type\nPress 1:Life\nPress 2:Health\nPress 3: Vehical\n Press 4: Property");
                                    bool isPolicyType = int.TryParse(Console.ReadLine(), out int policyType);
                                    if(!isPolicyType || policyType >4 || policyType < 1)
                                    {
                                        Console.WriteLine("\n Invalid input \nTry again");
                                        goto AddPolicy;
                                    }
                                    Console.WriteLine("Holder Name :");
                                    string holderName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(holderName))
                                    {
                                        Console.WriteLine("\n Invalid input\nTry again");
                                        goto AddPolicy;
                                    }
                                    Console.WriteLine("Policy Period:");
                                    bool isPolicyPeriod = int.TryParse(Console.ReadLine(), out int policyPeriod);
                                    if (!policyPeriod)
                                    {
                                        Console.WriteLine("\nInvalid input \nTry again");
                                        goto AddPolicy;
                                    }
                                    bool addedResult = policy.AddPolicy(id, holderName, policyType, policyPeriod);
                                    if (addedResult)
                                    {
                                        Console.WriteLine("Policy added successfully");
                                    }
                                    if (!addedResult)
                                    {
                                        Console.WriteLine("Something went wrong");
                                        goto YouHaveAccount;
                                    }
                                    else
                                    {
                                        goto Menu;
                                    }
                                }
                            case 2:
                                {
                                    Console.WriteLine("\nView all Policy");
                                    List<Policy> policies = policy.ViewAllPolicy(id);
                                    if (policies.Count>0)
                                    {
                                        policies.ForEach(policy =>
                                        {
                                            Console.WriteLine($"PolicyId::{policy.PolicyID}\tHolder Name::{policy.PolicyHolderName}\tPolicy type::{(Enums)policy.PolicyType}\tStart date::{policy.StartDate.ToString("dd/MM/yyyy")}\tEndDate::{policy.EndDate.ToString("dd/mm/yyyy")}");
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("No available policies");
                                    }
                                    goto Menu;
                                }

                            case 3:
                        }
                    }
                }
               


            }

        }
    }
}
