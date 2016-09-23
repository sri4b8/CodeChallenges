using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10thSeptember2016
{
   public class Program
    {
        public static void Main(string[] args)
        {

            int m = Convert.ToInt16(Console.ReadLine());
            int n = Convert.ToInt16(Console.ReadLine());
            var readLine = Console.ReadLine();
            string[] input = readLine.Split(' ');
            string[] start = Console.ReadLine().Split(' ');
            string[] end = Console.ReadLine().Split(' ');

            Point startPoint=new Point(Convert.ToInt16(start[0]), Convert.ToInt16(start[1]));
            Point endPoint = new Point(Convert.ToInt16(end[0]), Convert.ToInt16(end[1]));

            char[,] matrix = new char[m, n];

            for (int i = 0; i < m; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToChar(input[i * m + j]);

                }
            }
            Program prog=new Program();
            var path = prog.FindShortestPath(matrix, 4, 4, startPoint, endPoint);
            Console.WriteLine(path.Count>0? "YES " + (path.Count+1):"NO");
            Console.ReadKey();
        }
        public class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public  List<Point> FindShortestPath(char[,] matrix, int rows, int cols, Point s, Point e)
        {
            bool[,] visited = new bool[rows, cols];
            Point[,] parent = new Point[rows, cols];

            List<Point> path = new List<Point>();
            int pathLength = Int32.MaxValue;
            Queue q = new Queue();
            q.Enqueue(s);
            while (q.Count != 0)
            {
                Point curr = (Point)q.Dequeue();
                visited[curr.x, curr.y] = true;
                //Console.Write("({0}, {1}) ", curr.x, curr.y);

                if (curr.x == e.x && curr.y == e.y) //reaching the destination point
                {
                    List<Point> currPath = new List<Point>();
                    while (parent[curr.x, curr.y] != s)
                    {
                        curr = parent[curr.x, curr.y]; // collecting the path positions
                        currPath.Add(curr);
                       // Console.Write("({0}, {1}) ", curr.x, curr.y);
                    }
                    Console.WriteLine();
                    if (currPath.Count < pathLength)
                    {
                        path.Clear();
                        path.AddRange(currPath);
                    }
                }

                //checking the bottom position value of the cursor
                if (curr.y + 1 < cols && matrix[curr.x, curr.y + 1] != '0' && !visited[curr.x, curr.y + 1]) 
                {
                    q.Enqueue(new Point(curr.x, curr.y + 1));
                    parent[curr.x, curr.y + 1] = curr;
                }

                //checking the top position value of the cursor
                if (curr.y - 1 >= 0 && matrix[curr.x, curr.y - 1] != '0' && !visited[curr.x, curr.y - 1])
                {
                    q.Enqueue(new Point(curr.x, curr.y - 1));
                    parent[curr.x, curr.y - 1] = curr;
                }

                //checking the left position value of the cursor
                if (curr.x - 1 >= 0 && matrix[curr.x - 1, curr.y] != '0' && !visited[curr.x - 1, curr.y])
                {
                    q.Enqueue(new Point(curr.x - 1, curr.y));
                    parent[curr.x - 1, curr.y] = curr;
                }

                //checking the right position value of the cursor
                if (curr.x + 1 < rows && matrix[curr.x + 1, curr.y] != '0' && !visited[curr.x + 1, curr.y])
                {
                    q.Enqueue(new Point(curr.x + 1, curr.y));
                    parent[curr.x + 1, curr.y] = curr;
                }
            }

            return path;
        }
    }
}
