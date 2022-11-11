using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace LinqPerformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
