// Project Prolog
// Name: SueAnn Van Valkenburg
// CS3260 Section 001
// Project: Lab_05
// Date: 09/25/2022 1:22:00 PM
// Purpose: Learn how to store object instances in a dictionary and how to access them when they're in the dictionary.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;


namespace Lab05_SV_v1
{
        enum AccountState
        {
            @new, //use @ bc new is a keyword
            active,
            underaudit,
            frozen,
            closed
        }
        public class Program
        {
            static public string currentAcctNum;
            public static void Main(string[] args)
            {

                Console.WriteLine("Welcome to Bank Account Manager!");

                // firstObj = new SavingsAccount();
                var bankStorage = new DictBank();      

                //use that int to create loop for master class obj instances
                while (true){ //only exit if user input == exit

                    Console.WriteLine("Would you like to create an account or search for an exisiting? Options: Create, Search ");
                    string action = Console.ReadLine();
                    while (string.IsNullOrEmpty(action) | Regex.IsMatch(action.ToLower(), @"(create|search)") == false) {
                        Console.WriteLine(action + " is not a valid option. Options include: create or search. Please try again");
                        Console.WriteLine("Would you like to create an account or search for an exisiting? Options: Create, Search ");
                        action = Console.ReadLine();
                    }

                if (action.ToLower() == "create") {

              

                    //ask for account type
                    Console.WriteLine("What type of account are you creating? (Savings,Checking,CD)");
                    string accountType = Console.ReadLine();
                    //if (accountType.ToLower() == "exit") { break; }
                while (string.IsNullOrEmpty(accountType) | Regex.IsMatch(accountType.ToLower(), @"(savings|checking|cd)") == false){
                        Console.WriteLine("The account type given is invalid. Please try again");
                        Console.WriteLine("What type of account are you creating? (Savings,Checking,CD)");
                        accountType = Console.ReadLine();
                    }

                    if (accountType.ToLower() == "savings")
                    {
                        SavingsAccount newAccount = new SavingsAccount();
                        currentAcctNum = newAccount.GetAccountNum();
                        bankStorage.StoreAccount(newAccount);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(accountType + " account with account number: " + currentAcctNum + " has been created.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (accountType.ToLower() == "checking")
                    {
                        CheckingAccount newAccount = new CheckingAccount();
                        currentAcctNum = newAccount.GetAccountNum();
                        bankStorage.StoreAccount(newAccount);
                        Console.ForegroundColor = ConsoleColor.Green;
                         Console.WriteLine(accountType + " account with account number: " + currentAcctNum + " has been created.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    { //cd
                        CDAccount newAccount = new CDAccount();
                        currentAcctNum = newAccount.GetAccountNum();
                        bankStorage.StoreAccount(newAccount);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(accountType + " account with account number: " + currentAcctNum + " has been created.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    //find current obj
                    MasterClass currentAccount = bankStorage.FindAccount(currentAcctNum);


                    //NAME
                    Console.WriteLine("Enter Account Users Name:");
                    string inputName = Console.ReadLine();
                    while (currentAccount.SetName(inputName) == false)
                    {
                        Console.WriteLine("Account Users Name is invalid. Please try again");
                        Console.WriteLine("Enter Account Users Name:");
                        inputName = Console.ReadLine();
                    }
                    currentAccount.SetName(inputName);

                    //ADDRESS
                    Console.WriteLine("Enter Address:");
                    string inputaddress = Console.ReadLine();
                    while (Regex.IsMatch(inputaddress, @"^[a-zA-Z0-9\.\-, ]*$") == false){
                        Console.WriteLine("the address given is invalid. please try again");
                        Console.WriteLine("enter adress:");
                        inputaddress = Console.ReadLine();
                    }
                    currentAccount.SetAddress(inputaddress);


                    //BALANCE
                    Console.WriteLine("Enter Users Balance:");
                    string inputBalance = Console.ReadLine();

                    decimal currentBalance;

                    NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol
                                        | NumberStyles.AllowParentheses | NumberStyles.AllowLeadingSign;
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                    while (Decimal.TryParse(inputBalance, style, culture, out currentBalance) == false || Regex.IsMatch(inputBalance, @"^\$?[0-9]*\.[0-9][0-9]$") == false || currentAccount.SetBalance(currentBalance) == false)
                    {
                        Console.WriteLine("The balance given is invalid. Please try again");
                        Console.WriteLine("Enter Users Balance:");
                        inputBalance = Console.ReadLine();
                    }
                    currentAccount.SetBalance(currentBalance);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Balance: $" + currentAccount.GetBalance());
                    Console.ForegroundColor = ConsoleColor.White;


                    //STATE
                    Console.WriteLine("Enter Account State :");
                    Console.WriteLine("Ex) New, Active, UnderAudit, Frozen, Closed");
                    string inputState = Console.ReadLine();
                    string lwrInputState = inputState.ToLower();
                    AccountState currentState;
                    //try convert to enum
                    //don't accept ints for inputState
                    while (int.TryParse(lwrInputState, out _) || Enum.TryParse<AccountState>(lwrInputState, out currentState) == false)
                    {
                        Console.WriteLine("The state given is invalid. The options are New, Active, UnderAudit, Frozen, Closed. Please try again");
                        Console.WriteLine("Enter Account State:");
                        inputState = Console.ReadLine();
                    }
                    currentAccount.SetState(currentState);

                    //printout user
                    //Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine("\n-------------------------------------------------------------- ");
                    //Console.WriteLine("Account Created:");
                    //Console.WriteLine("Users Name: " + currentAccount.GetName());
                    //Console.WriteLine("Address: " + currentAccount.GetAddress());
                    //Console.Writeine("Account Service Fee: $" + currentAccount.GetServiceFee() + ".00");
                    //Console.WriteLine("\n-------------------------------------------------------------- ");

                    Console.ForegroundColor = ConsoleColor.White;

                    //DEPOSIT
                    Console.WriteLine("How much would you like to deposit?");
                    string inputdeposit = Console.ReadLine();
                    decimal currentAmount;

                    while (Decimal.TryParse(inputdeposit, style, culture, out currentAmount) == false || Regex.IsMatch(inputdeposit, @"^\$?[0-9]*\.[0-9][0-9]$") == false)//Validate here or in Account Class?
                    {
                        Console.WriteLine("Amount is invalid. Please try again");
                        Console.WriteLine("How much would you like to deposit?");
                        inputdeposit = Console.ReadLine();
                    }
                    currentAccount.PayInFunds(currentAmount);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Balance: $" + currentAccount.GetBalance());

                    //WITHDRAW
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("How much would you like to withdraw?");
                    string inputwithdraw = Console.ReadLine();
                    //decimal currentAmount2;

                    while (Decimal.TryParse(inputwithdraw, style, culture, out currentAmount) == false || Regex.IsMatch(inputwithdraw, @"^\$?[0-9]*\.[0-9][0-9]$") == false || currentAccount.WithdrawFunds(currentAmount) == false)//Validate here or in Account Class?
                    {
                        Console.WriteLine("Amount is invalid. Please try again");
                        Console.WriteLine("How much would you like to withdraw?");
                        inputwithdraw = Console.ReadLine();
                    }

                    currentAccount.WithdrawFunds(currentAmount);//while loop already calls it
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Balance: $" + currentAccount.GetBalance());

                    Console.ForegroundColor = ConsoleColor.White;

                }
                else { //action == "search"
                    Console.WriteLine("Enter the account number of the account you would like to search: ");
                    string accountNum = Console.ReadLine();
                    while (string.IsNullOrEmpty(accountNum) | Regex.IsMatch(accountNum, @"[0-9]{4}(C|D|S)") == false) {
                        Console.WriteLine("The account number " + accountNum + " is invalid. Please try again");
                        Console.WriteLine("Enter the account number of the account you would like to search: ");
                        accountNum = Console.ReadLine();
                    }
                    var searchedAccount = bankStorage.FindAccount(accountNum);
                    if (searchedAccount == null) {
                        Console.WriteLine("No such account under the account number " + accountNum + " exists.");
                    }
                    else { // output account
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("\n-------------------------------------------------------------- ");
                        Console.WriteLine("Users Name: " + searchedAccount.GetName());
                        Console.WriteLine("Address: " + searchedAccount.GetAddress());
                        Console.WriteLine("Account Number: " + searchedAccount.GetAccountNum());

                        string accountNumber = searchedAccount.GetAccountNum();
                        char lastCharacter = accountNumber[accountNumber.Length - 1];
                        if (lastCharacter == 'S') {
                            Console.WriteLine("Account Type: Savings");
                        }
                        else if (lastCharacter == 'C') {
                            Console.WriteLine("Account Type: Checking");
                        }
                        else //lastCharacter == 'D'
                        {
                            Console.WriteLine("Account Type: Certificate Deposit");
                        }




                        Console.WriteLine("Account Balance: " + searchedAccount.GetBalance());
                        Console.WriteLine("Account State: " + searchedAccount.GetState());
                        Console.WriteLine("Account Service Fee: $" + searchedAccount.GetServiceFee() + ".00");
                        Console.WriteLine("\n-------------------------------------------------------------- ");

                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }
            }
           
        }


        }
}


