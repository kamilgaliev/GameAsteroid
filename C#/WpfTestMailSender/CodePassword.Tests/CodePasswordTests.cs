using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodePassword.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        [TestMethod]
        public void getCodPassword_abc_bcd()
        {
            string strGetpass = "abc";
            string strChaingePass = "bcd";

            // act
            string strActual = CodePasswordTests.getCodePass(strGetpass);

            //assert
            Assert.AreEqual(strChaingePass, strActual);
        }
        [TestMethod]
        public void getCodPassword_abc_bcda_Error()
        {
            string strGetpass = "abc";
            string strChaingePass = "bcda";

            // act
            string strActual = CodePasswordTests.getCodePass(strGetpass);

            //assert
            Assert.AreEqual(strChaingePass, strActual);
        }
        public static string getCodePass(string pass)
        {
            string sCode = "";
            foreach(char p in pass)
            {
                char sP = p;
                sP++;
                sCode += sP;
            }
            return sCode;
        }
    }
}
