using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Code_Competitions.Google_Kick_Start._2020.Round_F
{
    class Metal_Harvest_Problem
    {

        public class Job
        {
            public int start { get; set; }
            public int end { get; set; }

            public int time => end - start;
            public Job(int Start, int End)
            {
                this.start = Start;
                this.end = End;
            }
        }


        //O(N Log N) | O(N)
        static void MainRenamed(string[] args)
        {
            TextReader reader = new StreamReader(@".\Google Kick Start\2020\Round F\MetalHarvest.txt");
            //TextReader reader = Console.In;
            TextWriter writer = Console.Out;

            int testCases = int.Parse(reader.ReadLine());
            string data = reader.ReadToEnd();
            string[] dataByLines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int LineNumber = 0;

            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                string[] splits = dataByLines[LineNumber++].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                int n = Convert.ToInt32(splits[0]);
                double timeSpan = Convert.ToInt32(splits[1]);

                List<Job> jobs = new List<Job>(n);

                for (int i = 0; i < n; i++)
                {
                    splits = dataByLines[LineNumber++].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    jobs.Add(new Job(Convert.ToInt32(splits[0]), Convert.ToInt32(splits[1])));
                }

                jobs = jobs.OrderBy(x => x.start).ToList();

                int robots = 0;
                int cur = 0;

                for (int i = 0; i < n; i++)
                {
                    cur = Math.Max(cur, jobs[i].start);
                    
                    //FF: I get Time Limit Exception because of this I have to optimize it with a division
                    //while(cur < jobs[i].end)
                    //{
                    //    robots++;
                    //    cur += Convert.ToInt32(timeSpan);
                    //}

                    if (cur < jobs[i].end)
                    {
                        int howMany = Convert.ToInt32(Math.Ceiling((jobs[i].end - cur) / timeSpan));
                        robots += howMany;
                        cur += (int)timeSpan * howMany;
                    }
                }

                Console.WriteLine("Case #" + testCase + ": " + robots);
            }
        }
    }
}
