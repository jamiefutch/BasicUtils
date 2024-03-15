using BasicUtils;

namespace csvtest
{
    internal class Program
    {
        const string Path = "XRX_2024-03-06_trades.csv";
        static void Main(string[] args)
        {
            var fields = Csv.GetHeadersFromFile(Path);
            var csv = Csv.Load(Path);
            foreach (var line in csv)
            {
                var count = 0;
                foreach (var s in line)
                {
                    Console.WriteLine($"{fields[count]}\t{s}");
                    count++;
                }
            }
        }
    }
}
