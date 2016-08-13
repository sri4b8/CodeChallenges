using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _12August2016;

namespace _12August2016UnitTest
{
    [TestClass]
    public class EncryptDecryptEngineTest
    {

        [TestMethod]
        public void EncryptMessageTest1()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "if man was meant to stay on the ground god would have given us roots";
            string expetedOutput = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau numsp 3 6 9 14 16 20 22 25 31 34 39 43 48 50";

            string actualOutput = engine.EncryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }

        [TestMethod]
        public void EncryptMessageTest2()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "have a nice day";
            string expetedOutput = "hae and via ecy numsp 5 6 10";

            string actualOutput = engine.EncryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }


        [TestMethod]
        public void EncryptMessageTest3()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "feed the dog";
            string expetedOutput = "fto ehg ee dd numsp 5 8";

            string actualOutput = engine.EncryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }


        [TestMethod]
        public void EncryptMessageTest4()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "chill out";
            string expetedOutput = "clu hlt io numsp 6";

            string actualOutput = engine.EncryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }


        [TestMethod]
        public void DecryptMessageTest1()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau numsp 3 6 9 14 16 20 22 25 31 34 39 43 48 50";
            string expetedOutput = "if man was meant to stay on the ground god would have given us roots";

            string actualOutput = engine.DecryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }

        [TestMethod]
        public void DecryptMessageTest2()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "hae and via ecy numsp 5 6 10";

            string expetedOutput = "have a nice day";

            string actualOutput = engine.DecryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }


        [TestMethod]
        public void DecryptMessageTest3()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "fto ehg ee dd numsp 5 8";
            string expetedOutput = "feed the dog";

            string actualOutput = engine.DecryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }


        [TestMethod]
        public void DecryptMessageTest4()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "clu hlt io numsp 6";
            string expetedOutput = "chill out";

            string actualOutput = engine.DecryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }



    }
}

