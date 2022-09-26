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

namespace Lab05_SV_v1
{
    ///<summary>
    /// This is an bankingArray interface that acts as a contract for derived classes
    /// </summary>
    interface IDictBank
    {
        public Dictionary<string, MasterClass> GetAccounts();
        public Boolean StoreAccount(MasterClass AcctObj);
        public MasterClass FindAccount(string AcctNum);



    }
}
