using BankingDomain;
using BankingUnitTest.TestDoubles;
using Moq;
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
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
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
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();


            Assert.Throws<OverdraftException>(() => account.Withdraw(openingBalance + 1M));
        }
    }
}
