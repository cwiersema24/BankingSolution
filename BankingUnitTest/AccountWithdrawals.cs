using BankingDomain;
using BankingUnitTest.TestDoubles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTest
{
    public class AccountWithdrawals
    {
        [Fact]
        public void WithdrawlDecreaseBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBlanace = account.GetBalance();
            var amountToWithdraw = 1M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBlanace - amountToWithdraw, account.GetBalance());
        }
        [Fact]
        public void CanTakeAllYourMoney()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            account.Withdraw(account.GetBalance());
            Assert.Equal(0, account.GetBalance());
        }
    }
}
