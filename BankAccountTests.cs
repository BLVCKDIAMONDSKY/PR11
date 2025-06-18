using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Credit_WithPositiveAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 100.00;
            double creditAmount = 25.50;
            double expected = 125.50;
            BankAccount account = new BankAccount("Mr.Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void AccountCreation_WithInitialBalance_SetsBalanceCorrectly()
        {
            // Arrange & Act
            var account = new BankAccount("Mr.Bryan Walton", 1000.50);

            // Assert
            Assert.AreEqual(1000.50, account.Balance);
            Assert.AreEqual("Mr.Bryan Walton", account.CustomerName);
        }

        [TestMethod]
        public void Credit_WithZeroAmount_DoesNotChangeBalance()
        {
            // Arrange
            var account = new BankAccount("Mr.Bryan Walton", 500.00);

            // Act
            account.Credit(0);

            // Assert
            Assert.AreEqual(500.00, account.Balance);
        }




        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 10, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
            account.Debit(debitAmount));
        }

        
    }
}