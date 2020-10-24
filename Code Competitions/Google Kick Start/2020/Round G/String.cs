using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

//https://codingcompetitions.withgoogle.com/kickstart/round/00000000001a0069/0000000000414bfb

namespace Code_Competitions.Google_Kick_Start._2020.Round_G
{
    class String
    {
        static void MainRenamed(string[] args)
        {
            TextReader reader = new StreamReader(@".\Google Kick Start\2020\Round G\data1.txt");
            //TextReader reader = Console.In;
            TextWriter writer = Console.Out;

            int testCases = int.Parse(reader.ReadLine());

            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                string header = reader.ReadLine();
                string[] splits = header.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string text = splits[0];

                int indexKICK = text.IndexOf("KICK");
                int indexSTART = text.IndexOf("START");

                int countKICKs = 0;
                int sum = 0;
                int currentIndex = 0;

                //O(N) O(1)
                while(indexSTART > -1)
                {
                    if(indexKICK > -1 && indexKICK < indexSTART)
                    {
                        countKICKs++;
                        currentIndex = indexKICK + "KICK".Length -1; //-1 BECAUSE IT STARTS AND ENDS WITH A K
                    }
                    else
                    {
                        sum += countKICKs;
                        currentIndex = indexSTART + "START".Length;
                    }

                    indexKICK = text.IndexOf("KICK",currentIndex );
                    indexSTART = text.IndexOf("START",currentIndex );
                }

                            
                Console.WriteLine("Case #" + testCase + ": " + sum);

            }
        }
    }
}
