using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Code_Competitions.Google_Kick_Start._2020.Round_F
{
    class ATM_Problem
    {
        public class Withdraw
        {
            public int originalOrderIndex { get; set; }
            public int amount { get; set; }

            public int timesNeedsToCycle { get; set; }
            public Withdraw(int Name, int Amount, int TimesNeedsToCycle)
            {
                this.originalOrderIndex = Name;
                this.amount = Amount;
                this.timesNeedsToCycle = TimesNeedsToCycle;
            }
        }

        //O(N Log N) | O(N)
        static void Main(string[] args)
        {
            TextReader reader = new StreamReader(@".\Google Kick Start\2020\Round F\ATM.txt");
            //TextReader reader = Console.In;
            TextWriter writer = Console.Out;

            int testCases = int.Parse(reader.ReadLine());

            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                string header = reader.ReadLine();
                string[] splits = header.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                int n = Convert.ToInt32(splits[0]);
                double max = Convert.ToInt32(splits[1]);

                string data = reader.ReadLine();
                string[] splitsData = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<Withdraw> list = new List<Withdraw>();
                int i = 1;
                foreach (string s in splitsData)
                {
                    int amountToWithdraw = Convert.ToInt32(s);
                    list.Add(new Withdraw(i, amountToWithdraw, Convert.ToInt32(Math.Ceiling(amountToWithdraw / max))));
                    i++;
                }

                //O(N Log N)
                var sorted = list.OrderBy(x => x.timesNeedsToCycle).ThenBy(x => x.originalOrderIndex);

                Console.WriteLine("Case #" + testCase + ": " + string.Join(" ", sorted.Select(x => x.originalOrderIndex).ToList()));

            }
        }
    }
}
