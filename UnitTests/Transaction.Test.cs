using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core;

namespace UnitTests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void Can_Read_Amount_And_Timestamp()
        {
            DateTime date = DateTime.Now;
            Transaction transaction = new(1000, date);

            Assert.AreEqual(1000, transaction.amount);
            Assert.AreEqual(date.ToString(), transaction.date.ToString());
        }
    }
}
