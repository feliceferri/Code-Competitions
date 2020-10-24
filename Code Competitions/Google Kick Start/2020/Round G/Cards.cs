using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace Code_Competitions.Google_Kick_Start._2020.Round_G
{
    class Cards
    {

        static void MainRenamed(string[] args)
        {
            TextReader reader = new StreamReader(@".\Google Kick Start\2020\Round G\cards.txt");
            //TextReader reader = Console.In;
            TextWriter writer = Console.Out;

            int testCases = int.Parse(reader.ReadLine());

            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                int n = Convert.ToInt32(reader.ReadLine());

                string header = reader.ReadLine();
                string[] splits = header.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<int> cards = new List<int>(n);
                foreach(string s in splits)
                {
                    cards.Add(Convert.ToInt32(s));
                }

                
                List<int> sums = MergeCards(cards, 0);

                double avg = sums.Average();


            Console.WriteLine("Case #" + testCase + ": " + avg.ToString() );

            }
        }


        private static List<int> MergeCards(List<int> cards, int currentSum)
        {
            List<int> res = new List<int>();

            if (cards.Count == 2)
            {
                res.Add(currentSum + cards[0] + cards[1]);
                return res;
            }

            for(int i = 1; i < cards.Count;i++)
            {
                List<int> copyOfCards = new List<int>(cards);
                int innerSum = currentSum + cards[i - 1] + cards[i];
                
                copyOfCards[i] = cards[i - 1] + cards[i];
                copyOfCards.RemoveAt(i-1);
                res.AddRange(MergeCards(copyOfCards, innerSum));
            }

            return res;
        }
    }
}
