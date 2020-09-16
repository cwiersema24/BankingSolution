﻿using BankingDomain;
using BankingUnitTest.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTest
{
    public class AccountDeposits
    {
        [Fact]
        public void DepositINcreacesBalance()
        {
            //given
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 5M;

            //when
            account.Deposit(amountToDeposit);

            //then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
