using System.Diagnostics;
using System.Text;

const string FilePath = "server_logs.txt";
const int FileSizeInMB = 500; // 1024 (1GB) 5000 (5GB)
const int BufferSize = 65536; // 64KB Write Buffer


Console.WriteLine($"Generating {FileSizeInMB}MB log file at: {FilePath}...");

var random = new Random();

var ipPool = new List<string>();
for (int i = 0; i < 50; i++) ipPool.Add($"192.168.1.{i}");
for (int i = 0; i < 50; i++) ipPool.Add($"10.0.0.{i}");

var validationStats = new Dictionary<string, int>();

long totalBytesWritten = 0;
const long targetBytes = (long)FileSizeInMB * 1024 * 1024;
        
var stopwatch = Stopwatch.StartNew();

using (var writer = new StreamWriter(FilePath, false, Encoding.UTF8, BufferSize))
{
    while (totalBytesWritten < targetBytes)
    {
        int index = (int)(Math.Pow(random.NextDouble(), 3) * ipPool.Count); 
        string ip = ipPool[index];

        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        int duration = random.Next(10, 5000); // 10ms to 5s
        string path = $"/api/v1/resource/{random.Next(1, 100)}";

        string line = $"timestamp={timestamp};ip={ip};duration={duration}ms;path={path}";

        validationStats.TryAdd(ip, 0);
        validationStats[ip]++;

        writer.WriteLine(line);
        totalBytesWritten += line.Length + 2; 
    }
}

stopwatch.Stop();
Console.WriteLine($"\nDone. File generated in {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
Console.WriteLine($"Total Lines: {validationStats.Values.Sum():N0}");