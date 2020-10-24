using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace Code_Competitions.Google_Kick_Start._2020.Round_G
{

    //https://codingcompetitions.withgoogle.com/kickstart/round/00000000001a0069/0000000000414a23
    class Coins
    {

        static void MainRenamed(string[] args)
        {
            //TextReader reader = new StreamReader(@".\Google Kick Start\2020\Round G\Coins.txt");
            TextReader reader = Console.In;
            TextWriter writer = Console.Out;

            int testCases = int.Parse(reader.ReadLine());

            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                int n = Convert.ToInt32(reader.ReadLine());

                int[,] matrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    string[] splits = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int c = 0;
                    foreach(string s in splits)
                    {
                        matrix[i, c] = Convert.ToInt32(s);
                        c++;
                    }
                }

                long maxSum = 0;

                //O(WxH) O(1)

                ///Right half
                for(int c = 0; c < n ; c++ )
                {
                    long currentSum = 0;
                    int r = 0;
                    int inner_c = c;
                    while( r < n - c && inner_c < n)
                    {
                        currentSum += matrix[r, inner_c];
                        r++;
                        inner_c++;
                    }

                    maxSum = Math.Max(currentSum, maxSum);
                }

                ///Left half
                for (int r = 1; r < n; r++)
                {
                    long currentSum = 0;
                    int c = 0;
                    int inner_r = r;
                    while (c < n - r && inner_r < n)
                    {
                        currentSum += matrix[inner_r, c];
                        inner_r++;
                        c++;
                    }

                    maxSum = Math.Max(currentSum, maxSum);
                }


                Console.WriteLine("Case #" + testCase + ": " + maxSum);

            }
        }
    }
}
