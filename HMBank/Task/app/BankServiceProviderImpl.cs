using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.service;

namespace Task.app
{
    internal class BankServiceProviderImpl : CustomerServiceProviderImpl, IBankServiceProvider
    {
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }

        public BankServiceProviderImpl(string branchName, string branchAddress)
        {
            BranchName = branchName;
            BranchAddress = branchAddress;
        }
    }
}
