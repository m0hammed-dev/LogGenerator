using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LogGenerator
{
    public static class LogAnalyzer
    {
        public static void Analyze(string filePath)
        {
            try
            {
                var ipCounts = new ConcurrentDictionary<string, long>();

                var stopwatch = Stopwatch.StartNew();

                Parallel.ForEach(File.ReadLines(filePath), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, line =>
                {

                    var ip = ExtractIp(line);
                    if (ip != null)
                    {
                        ipCounts.AddOrUpdate(ip, 1, (_, count) => count + 1);
                    }

                });

                var top5 = ipCounts
                    .OrderByDescending(x => x.Value)
                    .Take(5)
                    .ToList();

                Console.WriteLine("Top 5 ips");

                foreach (var ip in top5)
                {
                    Console.WriteLine($"{ip.Key} => {ip.Value}");
                }
                stopwatch.Stop();
                Console.WriteLine($"\nDone. File analysed  in {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static string? ExtractIp(string line)
        {
            var start = line.IndexOf("ip=");
            if (start == -1)
                return null;

            start += 3;
            var end = line.IndexOf(';', start);
            if (end == -1)
                return null;
            return line.Substring(start, end - start);
        }


    }
}
