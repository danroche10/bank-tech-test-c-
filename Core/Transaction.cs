using System;
using System.Collections.Generic;

namespace Core
{
    public class Transaction : ITransaction
    {

        public double amount
        { get;  }
        public DateTime date
        { get; }

        public Transaction(double amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
        }

    }
}
