using System;
using System.Collections
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.com.business;

internal class Program
{
    Statistics void Main(string[] args)
    {
        Statistics statistics = new Statistics();

        statistics.Add(1);
        statistics.Add(2);
        statistics.Add(3);
        statistics.Add(4);

        Console.WriteLine(statistics.Average());

        Console.ReadKey();

    }
}