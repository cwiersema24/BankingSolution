using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTest
{
    public class StandardBonusCalculatorTests
    {
        [Fact]
        public void BonusBeforeCutoff()
        {
            var cutoffClockStub = new Mock<IProvideTheCutoffClock>();
            cutoffClockStub.Setup(c => c.BeforeCutoff()).Returns(true);
            var calculator = new StandardBonusCalculator(cutoffClockStub.Object);
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(10, bonus);
        }

        [Fact]
        public void BonusAfterCutoff()
        {
            var cutoffClockStub = new Mock<IProvideTheCutoffClock>();
            cutoffClockStub.Setup(c => c.BeforeCutoff()).Returns(false);
            var calculator = new StandardBonusCalculator(cutoffClockStub.Object);
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(8, bonus);
        }
    }
    //public class BeforeCutoffBonusCalculaotr : StandardBonusCalculator 
    //{
    //    protected override bool BeforeCutoff()
    //    {
    //        return true;
    //    }
    //}
    //public class AfterCutoffBonusCalculaotr : StandardBonusCalculator 
    //{
    //    protected override bool BeforeCutoff()
    //    {
    //        return false;
    //    }
    //}
}
