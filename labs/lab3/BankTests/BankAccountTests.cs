using BankAccountNS;

namespace BankAccountNS.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        // unit test code
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod()]
        public void subtractingGreaterAmount()
        {
            double beginningBalance = 11.99;
            double debitAmount = 15.00;
            BankAccount account = new BankAccount("Mr. Funny Man", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "amount");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void subtractingNegative()
        {
            double beginningBalance = 100000000000.99;
            double debitAmount = -5.00;
            BankAccount account = new BankAccount("Mr Gal Florenthal", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "amount");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void subtractingZero()
        {
            double beginningBalance = 0.01;
            double debitAmount = 0;
            double expected = 0.01;
            BankAccount account = new BankAccount("Mr Itay Rosen", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod()]
        public void frozenAccount()
        {
            double beginningBalance = 10.50;
            double debitAmount = 5.10;
            BankAccount account = new BankAccount("Mr John Cena", beginningBalance);
            account.FreezeAccount();

            try
            {
                account.Debit(debitAmount);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(Exception), e.GetType());
                StringAssert.Contains(e.Message, "Account frozen");
                Assert.AreEqual(beginningBalance, account.Balance, 0.001, "A frozen account cannot be debited.");
                
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void subtractingWhenMBalanceIsNegative()
        {
            double beginningBalance = -10.00;
            double debitAmount = 1.00;
            BankAccount account = new BankAccount("    @!#%%9073ליגדכbanana", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "amount");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void subtractingWhenBuilderIsEmpty()
        {
            double debitAmount = 10.00;
            BankAccount account = new BankAccount();

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "amount");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }
    }
}
