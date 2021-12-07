using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core;

namespace UnitTests
{
    [TestClass]
    public class TransactionFactoryTests
    {
        [TestMethod]
        public void Can_Create_A_Transaction()
        {
            DateTime date = DateTime.Now;
            ITransactionFactory transactionFactory = new TransactionFactory();
            ITransaction transaction = transactionFactory.Create(1000, date);

            Assert.AreEqual(1000, transaction.amount);
            Assert.AreEqual(date.ToString(), transaction.date.ToString());
        }
    }
}
