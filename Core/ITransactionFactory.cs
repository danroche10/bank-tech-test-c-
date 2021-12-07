 using System;

namespace Core
{
    public interface ITransactionFactory
    {
        ITransaction Create(double amount, DateTime date);
    }
}