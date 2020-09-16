using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BankingDomain;
using BankingUnitTest.TestDoubles;
using Moq;

namespace BankingUnitTest
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            //Given
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object);

            //When
            decimal balance = account.GetBalance();

            //Then
            Assert.Equal(1000M, balance);
        }
    }
}
