using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTest
{
    public class CannotDoTransactionsWithNegativeAmounts
    {
        //[Fact]
        //public void DepositsAllowNegativeNumbers()
        //{
        //    var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
        //    var openingBalance = account.GetBalance();
        //    account.Deposit(-100);
        //    Assert.Equal(openingBalance - 100, account.GetBalance());
        //}
        [Fact]
        public void DepositsDoNotAllowNegativeNumbers()
        {
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            Assert.Throws<NoNegativeTransactionsException>(() => account.Deposit(-100));
            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
