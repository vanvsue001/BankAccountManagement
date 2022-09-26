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
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab05_SV_v1{
        ///<summary>
        /// This is an dervied class from IArrayBank interface that saves accounts and finds classes given their id property
        /// </summary>
        class DictBank : IDictBank{
            
            static public Dictionary<string, MasterClass> accounts = new Dictionary<string, MasterClass> (); 
            
            public MasterClass FindAccount(string AcctNum){
                if (accounts.ContainsKey(AcctNum)){

                    var value = accounts[AcctNum];
                    return value;
                }
                return null; //default null means key not found
            }

            //store obj as serailized json obj
            public Dictionary<string, MasterClass> GetAccounts(){
                return accounts;
            }

            public bool StoreAccount(MasterClass AcctObj){
            var key = AcctObj.GetAccountNum();
            var value = AcctObj;
                //check if key is null or key already exists in dict
                //accounts.ContainsKey(key)
                if (key != null || AcctObj != null) {
                    
                    accounts.Add(key, value);
                    return true;
                }
                else { 
                    return false;
                }
            }
        }
}


