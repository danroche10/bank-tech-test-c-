using System;
using System.Collections.Generic;

namespace Core
{
    public class  Printer : IPrinter
    {
        public string PrintStatement(List<ITransaction> transactions)
        {
            var report = new System.Text.StringBuilder();
            double balance = 0;
            report.Append("Date\t\tAmount\tBalance\tNote");
            foreach (var transaction in transactions)
            {
                balance += transaction.amount;
                report.Append($"\n{transaction.date.ToShortDateString()}\t{transaction.amount}\t{balance}");
            }
            return report.ToString();
        }
    }
}
