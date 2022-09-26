﻿// Project Prolog
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

namespace Lab05_SV_v1
{
        ///<summary>
        /// This is an dervied class from MasterClass that models a checking banking account. It contains key information
        /// about an account and methods to manage that data
        /// </summary>
        class CheckingAccount : MasterClass
        {
            enum AccountState
            {
                @new, //use @ bc new is a keyword
                active,
                underaudit,
                frozen,
                closed
            }
            //properties


            //intstance variables
            String name;
            String address;
            Decimal balance;
            decimal serviceFee = 5;
            Enum state; //enum
            string AccountNumber; //private? might need to be public bc getter and setter
            private const Decimal MinBalance = 10;

            //constructor
            public CheckingAccount()
            {
                this.AccountNumber = AccountNumGen();
                this.serviceFee = 5;
            }
            public CheckingAccount(string name, string address, decimal balance)
            {
                this.AccountNumber = AccountNumGen();
                this.name = name;
                this.address = address;
                this.balance = balance;
                this.AccountNumber = AccountNumGen();
                this.serviceFee = 5;
            }



            //overide methods
            public override decimal GetServiceFee()
            {
                return serviceFee;
            }
            public override decimal GetBalance()
            {
                return balance;
            }

            public override bool SetBalance(decimal inBalance)
            {
                if (inBalance >= MinBalance)
                {

                    balance = inBalance;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override decimal GetMinBalance()
            {
                return MinBalance;
            }

            public override string GetAccountNum()
            {
                return AccountNumber;
            }

            static int i = 0;
            public override string AccountNumGen()
            {
                i += 1;
                string strI = i.ToString();
                while (strI.Length != 4)
                {
                    string newStrI = "0" + strI;
                    strI = newStrI;
                }

                return strI + 'C';
            }
        }
}


