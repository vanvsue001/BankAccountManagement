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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Lab05_SV_v1
{
    ///<summary>
    /// This is an abstarct base class that models a standard banking account. It contains key information
    /// about an account and methods to manage that data
    /// </summary>
    abstract class MasterClass
        {
            // properties
            private string name;
            private string address;
            private string accountNumber;
            private decimal balance;
            private Enum state;
            public decimal serviceFee;
            //abstract methods
            public abstract Boolean SetBalance(decimal inBalance);
            public abstract decimal GetBalance();
            public abstract string GetAccountNum();
            public abstract string AccountNumGen();
            public abstract decimal GetMinBalance();
            public abstract decimal GetServiceFee();


            //non-abstract method

            /// <summary>
            /// Purpose: To withdraw money from an accounts balance 
            /// </summary>
            /// <param name="amount">a positive decimal value, that would leave account greater than account types minimum balance </param>
            /// <returns>true if sucessful and false if unsucessful</returns>
            public Boolean WithdrawFunds(decimal amount)
            {
                //need to check amount is positive and valid number
                //must be greater than 0 || MinBalance
                decimal currentBalance = GetBalance();
                decimal currentMin = GetMinBalance();
                if (currentBalance - amount < currentMin)
                {
                    return false;
                }
                else
                {
                    decimal newBalance = currentBalance - amount;
                    SetBalance(newBalance);
                    return true;
                }
            }

            public void PayInFunds(decimal inAmount)
            {
                decimal currentBalance = GetBalance();
                decimal newBalance = currentBalance + inAmount;
                SetBalance(newBalance);
            }

            public Boolean SetName(string inName)
            {
                if (inName == null || inName == "" || Regex.IsMatch(inName, @"^[a-zA-Z ]+$") == false)
                { //check name valitity 
                    return false;
                }
                else
                {
                    name = inName;
                    return true;
                }
            }
            public string GetName()
            {
                return name;
            }

            public Boolean SetAddress(string inAddress)
            {
                if (inAddress == null || inAddress == "")
                { //check name valitity 
                    return false;
                }
                else
                {
                    address = inAddress;
                    return true;
                }
            }
            public string GetAddress()
            {
                return address;
            }

            public void SetState(Enum inState)
            { //check enum before passing
                state = inState;
            }
            public Enum GetState()
            {
                return state;
            }


            public void SetServiceFee(decimal inFee)
            {//check decimal validity before passed in
                serviceFee = inFee;
            }


        }
}


