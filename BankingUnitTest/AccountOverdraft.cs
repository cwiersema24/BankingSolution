using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTest
{
    public class AccountOverdraft
    {
        [Fact]
        public void BalanceStaysTheSame()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1M);
            }
            catch (OverdraftException)
            {

                //gulp
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverdraftGivesException()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            account.Withdraw(openingBalance + 1M);
            bool caught = false;

            Assert.Throws<OverdraftException>(() => account.Withdraw(openingBalance + 1M));
        }
    }
}
