using System;
using System.Collections.Generic;

namespace Core
{
    public class BankAccount
    {
        private readonly ITransactionFactory _transactionFactory;
        private readonly IPrinter _printer;
        public List<ITransaction> allTransactions = new List<ITransaction>();

        public int Number
                { get; }
            public double Balance
                { get {

                double balance = 0;
                foreach (var transaction in allTransactions)
                {
                    balance += transaction.amount;
                }
                return balance;
            } }

        public BankAccount() : this(new TransactionFactory(), new Printer()) { }
        public BankAccount(ITransactionFactory transactionFactory) : this(transactionFactory, new Printer()) { }
        public BankAccount(IPrinter printer) : this(new TransactionFactory(), printer) { }
        public BankAccount(List<ITransaction> transactions) : this(new TransactionFactory(), new Printer(), transactions) { }
        public BankAccount(ITransactionFactory transactionFactory, IPrinter printer) : this(transactionFactory, printer, new List<ITransaction>()) { }
        public BankAccount(ITransactionFactory transactionFactory, IPrinter printer, List<ITransaction> transactions)
        {
            _transactionFactory = transactionFactory;
            _printer = printer;
        }

        public void MakeDeposit(double amount, DateTime date)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit Amount must be positive");
            }
            allTransactions.Add(_transactionFactory.Create(amount, date));

        }

        public void MakeWithdrawal(double amount, DateTime date)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal Amount must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You do not have sufficient funds for this withdrawal");
            }
            allTransactions.Add(_transactionFactory.Create(-amount, date));
        }

        public string GetAccountHistory()
        {
            return _printer.PrintStatement(allTransactions);

        }


    }
}
