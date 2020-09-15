namespace BankingDomain
{
    public class GoldAcount:BankAccount
    {
        public override void Deposit(decimal amountToDeposit)
        {
            base.Deposit(amountToDeposit * 1.10M);
        }
    }
}