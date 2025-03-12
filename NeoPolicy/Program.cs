using NeoPolicy.Interfaces;
using NeoPolicy.Models;
using NeoPolicy.Repositories;
using System.ComponentModel.Design;

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

            if (!isAccountOption || accountOption > 3 || accountOption < 1)
            {
                Console.WriteLine("\n Invalid input \n Try again");
                goto YouHaveAccount;
            }
            IloginandRegister loginAndRegister = new LoginandRegister();
        LoginForm:
            if (accountOption == 1)
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
                    if (innterOption == 1)
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
                                    if (!isPolicyType || policyType > 4 || policyType < 1)
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
                                    if (policies.Count > 0)
                                    {
                                        policies.ForEach(policy =>
                                        {
                                            Console.WriteLine($"PolicyId::{policy.PolicyID}\tHolder Name::{policy.PolicyHolderName}\tPolicy type::{(Enums)policy.PolicyType}\tStart date::{policy.StartDate.ToString("dd/MM/yyyy")}\tEndDate::{policy.EndDate.ToString("dd/MM/yyyy")}");
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("No available policies");
                                    }
                                    goto Menu;
                                }

                            case 3: SearchByPolicyId:
                                Console.WriteLine("\n Search policy by id");
                                Console.WriteLine("Enter Id:");
                                bool isPolicyId = int.TryParse(Console.ReadLine(), out int policyId);
                                if (isPolicyId)
                                {
                                    List<Policy> policies = policy.SearchPolicyById(id, policyId);
                                    if (policies.Count > 0)
                                    {
                                        policies.ForEach(policy =>
                                        {
                                            Console.WriteLine($"PolicyId::{policy.PolicyID}\tPolicy type::{(Enums)policy.PolicyType}\tStart date::{policy.StartDate.ToString("dd/MM/yyyy")}\tEnd date::{policy.EndDate.ToString("dd/MM/yyyy")}");
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("No policy with id" + policyId);
                                    InnerOption:
                                        Console.WriteLine("Press 1: Try again");
                                        Console.WriteLine("Press 2: Go to Menu");
                                        bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                                        if (!isInnerOption || innterOption > 2 || innterOption < 1)
                                        {
                                            Console.WriteLine("\n Invalid input");
                                        }
                                        if (innterOption == 1)
                                        {
                                            goto SearchByPolicyId;
                                        }
                                        if (innterOption == 2)
                                        {
                                            goto Menu;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input \nTry again");
                                    goto SearchByPolicyId;
                                }
                                goto Menu;
                        } 
                   




                        case 4:
                            {
                            UpdateByPolicyId:
                                Console.WriteLine("\n Update policy by id");
                                Console.WriteLine("Enter Id");
                                bool isPolicyId = int.TryParse(Console.ReadLine(), out int policyId);
                                if (isPolicyId)
                                {
                                    bool isSuccess = policy.UpdatePolicyById(id, policyId);
                                    if (isSuccess)
                                    {
                                        Console.WriteLine($"Policy with id:{policyId} update successfully");
                                    }
                                    if (!isSuccess)
                                    {
                                        Console.WriteLine("Invalid PolicyId :" + policyId);
                                    InnerOption:
                                        Console.WriteLine("Press 1:Try again");
                                        Console.WriteLine("Press 2:Go to menu");
                                        bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                                        if (!isInnerOption || innterOption > 2 || innterOption < 1)
                                        {
                                            Console.WriteLine("\n Invalid input");
                                            goto InnerOption;
                                        }
                                        if (innterOption == 1)
                                        {
                                            goto UpdateByPolicyId;
                                        }
                                        if (innterOption == 2)
                                        {
                                            goto Menu;
                                        }

                                    }
                                }



                                else
                                {
                                    Console.WriteLine("\n Invalid input \n Try again");
                                    goto UpdateByPolicyId;

                                }
                                goto Menu;
                            }
                        case 5:
                            {
                            DeleteByPolicyId:
                                Console.WriteLine("\n Delete Policy by id");
                                Console.WriteLine("Enter he Id:");
                                bool isPolicyId = int.TryParse(Console.ReadLine(), out int policyId);
                                if (isPolicyId)
                                {
                                    bool isSuccess = policy.DeletePolicy(id, policyId);
                                    if (isSuccess)
                                    {
                                        Console.WriteLine($"Policy with id:{policyId} deleted successfully");
                                    }
                                    if (!isSuccess)
                                    {
                                        Console.WriteLine("No policy with id " + policyId);

                                    InnerOption:
                                        Console.WriteLine("Press 1:Try again");
                                        Console.WriteLine("Press 2: Go to menu");
                                        bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                                        if (!isInnerOption || innterOption > 2 || innterOption < 1)
                                        {
                                            Console.WriteLine("\n Invalid input");
                                            goto InnerOption;
                                        }
                                        if (innterOption == 1)
                                        {
                                            goto DeleteByPolicyId;
                                        }
                                        if (innterOption == 2)
                                        {
                                            goto Menu;
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("\n Invalid input \nTry again");
                                    goto DeleteByPolicyId;
                                }
                                goto Menu;
                            }

                        case 6:
                            {
                                Console.WriteLine("\n View active policy");
                                List<Policy> policies = policy.ShowActivePolicy(id);
                                if (policies.Count > 0) {
                                    policies.ForEach(policy =>
                                    {
                                        Console.WriteLine($"PolicyId::{policy.PolicyID}\t Holder name::{policy.PolicyHolderName}\tPolicy type::{(Enums)policy.PolicyType}\t Start date::{policy.StartDate.ToString("dd/MM/yyyy")}\tEnd date::{policy.EndDate.ToString("dd/MM/yyyy")}");

                                    });
                                }
                                else {
                                    Console.WriteLine("No available policies");
                                }
                                goto Menu;
                            }

                        default:
                            {
                                accountOption = 4;
                                goto LoginForm;
                            }

                        }

                    }
                    else
                    {

                        accountOption = 4;
                        goto LoginForm;
                    }
                }

                else
                {
                InnerOption:
                    Console.WriteLine("\nInvalid credentials");
                    Console.WriteLine("Press 1: Try again");
                    Console.WriteLine("Press 2 : Go to start page");

                    bool isInnerOption = int.TryParse(Console.ReadLine(), out int innterOption);
                    if (!isInnerOption || innterOption > 2 || innterOption < 1)
                    {
                        goto InnerOption;
                    }
                    if (innterOption == 1)
                    {
                        goto LoginForm;
                    }
                    if (innterOption == 2)
                    {
                        goto YouHaveAccount;
                    }
                    goto LoginForm;
                }
            }
            if (accountOption == 2)
            {
                Console.WriteLine("\n Register Form");
                Console.Write("Name : ");
                string name = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();
                loginAndRegister.Register(name, password);
                accountOption = 1;
                goto LoginForm;
            }
            if (accountOption == 4)
            {
                id = -1;
                Console.WriteLine("Logged out Successfully");
                goto YouHaveAccount;
            }
            Console.WriteLine("\n Program terminated successfully");
        }
    }
}
