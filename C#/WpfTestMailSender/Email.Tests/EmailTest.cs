using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Email.Tests
{
    [TestClass]
    public class EmailTest
    {
        
        [TestMethod]
        public void getCorrectEmail()
        {
            string correctEmail = "test@test.ru";
            bool b = isValid(correctEmail);
            Assert.AreEqual(true, b);
        }
        [TestMethod]
        public void getBadEmail()
        {
            string correctEmail = "test.test.ru";
            bool b = isValid(correctEmail);
            Assert.AreEqual(false, b);
        }

        public bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
