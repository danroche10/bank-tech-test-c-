using System;

namespace Core
{
    public interface ITransaction
    {
        double amount { get; }
        DateTime date { get; }
    }
}