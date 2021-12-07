using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core;
using Moq;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class PrinterTests
    {
        private List<ITransaction> mockTransactions;

        [TestInitialize]
        public void On_Initialize()
        {
            Mock<ITransaction> mockDeposit = new();
            Mock<ITransaction> mockWithdrawal = new();
            mockDeposit.Setup(t => t.date).Returns(DateTime.Parse("Jan 10, 2021"));
            mockDeposit.Setup(t => t.amount).Returns(1000);
            mockWithdrawal.Setup(t => t.date).Returns(DateTime.Parse("Jan 11, 2021"));
            mockWithdrawal.Setup(t => t.amount).Returns(-500);
            mockTransactions = new List<ITransaction> { mockDeposit.Object, mockWithdrawal.Object };
        }

        [TestMethod]
        public void Can_Print_Full_Statement()
        {
            Printer printer = new();

            string statement = printer.PrintStatement(mockTransactions);

            Assert.AreEqual("Date\t\tAmount\tBalance\tNote\n10/01/2021 || 1000.00 || - || 1000.00\n11/01/2021 || - || 500.00 || 500.00", statement);
        }
    }
}
