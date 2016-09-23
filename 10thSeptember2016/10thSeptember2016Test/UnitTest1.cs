using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _10thSeptember2016;

namespace _10thSeptember2016Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program prog = new Program();
            Program.Point startPoint = new Program.Point(0, 1);
            Program.Point endPoint = new Program.Point(3, 2);
            int m = 4, n = 4;
            string[] input = ("0 1 1 0 1 1 1 1 1 1 0 1 0 1 1 1").Split(' ');
            char[,] matrix = new char[m, n];

            for (int i = 0; i < m; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToChar(input[i * m + j]);

                }
            }
            var path = prog.FindShortestPath(matrix, 4, 4, startPoint, endPoint);

            Assert.AreEqual(path.Count + 1, 4);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Program prog = new Program();
            Program.Point startPoint = new Program.Point(0, 1);
            Program.Point endPoint = new Program.Point(2, 1);
            int m = 4, n = 4;
            string[] input = ("0 1 1 0 1 0 1 1 1 1 0 1 0 0 1 1").Split(' ');
            char[,] matrix = new char[m, n];

            for (int i = 0; i < m; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToChar(input[i * m + j]);

                }
            }
            var path = prog.FindShortestPath(matrix, 4, 4, startPoint, endPoint);

            Assert.IsTrue(path == null || path.Count == 0);

        }
    }
}
