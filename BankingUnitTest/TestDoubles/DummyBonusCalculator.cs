﻿using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingUnitTest.TestDoubles
{
    public class DummyBonusCalculator : ICalculateBankAccountBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
