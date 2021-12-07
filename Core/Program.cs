using System;
using Core;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            //var transaction = new Transaction(100, DateTime.Now, "test");

            var account = new BankAccount(new TransactionFactory());
            account.MakeDeposit(200, DateTime.Now);
            account.MakeWithdrawal(100, DateTime.Now);
            Console.Write(account.GetAccountHistory());


            //Console.WriteLine(transaction.note);
        }
    }
}
