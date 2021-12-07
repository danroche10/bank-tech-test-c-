using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class BankAccountTEsts
    {
        private Mock<ITransactionFactory> mockTransactionFactory;
        private Mock<ITransaction> mockTransaction;

        [TestInitialize]
        public void On_Initialize()
        {
            mockTransactionFactory = new Mock<ITransactionFactory>();
            mockTransaction = new Mock<ITransaction>();
            mockTransaction.Setup(tf => tf.amount).Returns(1000);
            mockTransactionFactory.Setup(tf => tf.Create(It.IsAny<double>(), DateTime.Parse("Jan 10, 2021"))).Returns(mockTransaction.Object);
        }

        [TestMethod]
        public void Can_Deposit()
        {
            BankAccount bankAccount = new(mockTransactionFactory.Object);

            bankAccount.MakeDeposit(200, DateTime.Parse("Jan 10, 2021"));

            mockTransactionFactory.Verify(tf => tf.Create(200, DateTime.Parse("Jan 10, 2021")));

            Assert.AreEqual(1, bankAccount.allTransactions.Count);
            Assert.AreEqual(mockTransaction.Object, bankAccount.allTransactions[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Error_Thrown_When_Deposit_Amount_LessThanZero()
        {
            BankAccount bankAccount = new(mockTransactionFactory.Object);

            bankAccount.MakeDeposit(-1000, DateTime.Parse("Jan 10, 2021"));
        }

        [TestMethod]
        public void Make_Deposit_Updates_Balance()
        {
            BankAccount bankAccount = new(mockTransactionFactory.Object);

            bankAccount.MakeDeposit(1000, DateTime.Parse("Jan 10, 2021"));

            Assert.AreEqual(1000, bankAccount.Balance);
        }

        [TestMethod]
        public void Can_Withdraw()
        {
            BankAccount bankAccount = new(mockTransactionFactory.Object);

            // Need to deposit funds in order to withdraw
            bankAccount.MakeDeposit(1000, DateTime.Parse("Jan 10, 2021"));

            bankAccount.MakeWithdrawal(1000, DateTime.Parse("Jan 10, 2021"));

            mockTransactionFactory.Verify(tf => tf.Create(-1000, DateTime.Parse("Jan 10, 2021")));

            Assert.AreEqual(2, bankAccount.allTransactions.Count);
            Assert.AreEqual(mockTransaction.Object, bankAccount.allTransactions[1]);
        }


        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Error_Thrown_When_Withdrawal_Amount_LessThanZero()
        {
            BankAccount bankAccount = new(mockTransactionFactory.Object);

            bankAccount.MakeWithdrawal(-1000, DateTime.Parse("Jan 10, 2021"));

        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Error_Thrown_When_Withdrawal_Takes_BalanceBelowZero()
        {
            BankAccount bankAccount = new(mockTransactionFactory.Object);

            bankAccount.MakeWithdrawal(2000, DateTime.Parse("Jan 10, 2021"));

        }
        
    }
}
