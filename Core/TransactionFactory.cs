using System;
namespace Core
{
    public class TransactionFactory : ITransactionFactory
    {
        public ITransaction Create(double amount, DateTime date)
        {
            return new Transaction(amount, date);
        }

        protected virtual ITransaction GetTransaction(double amount, DateTime date)
        {
            return new Transaction(amount, date);
        }
    }
}
