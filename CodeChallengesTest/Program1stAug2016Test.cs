using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenges;


namespace CodeChallengesTest
{
    [TestClass]
    public class Program1stAug2016Test
    {  
       Program1stAug2016  program=new Program1stAug2016();
        [TestMethod]
        public void TestMethod1()
        {
            int[] inputValues = new int[3] {1,2,3 };
            bool result = program.isSame(inputValues);
            Assert.IsFalse(result);             
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] inputValues = new int[4] { 11,20,8,31 };
            bool result = program.isSame(inputValues);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] inputValues = new int[8] {  1,9,21,35,61,65,62,72};
            bool result = program.isSame(inputValues);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] inputValues = new int[10] { 1,4,9,3,6,7,5,8,6,4 };
            bool result = program.isSame(inputValues);
            Assert.IsTrue(result);
        }
    }
}
