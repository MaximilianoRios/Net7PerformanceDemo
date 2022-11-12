using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Linq;

namespace LinqPerformance
{
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        [Params(100)]
        public int Size { get; set; }

        private IEnumerable<int> _items;
        private IEnumerable<int> _items2;

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(1, Size).ToArray();
            _items2 = Enumerable.Range(1, Size).ToList();
        }

        [Benchmark]
        public void Min() => _items.Min();

        [Benchmark]
        public void Max() => _items.Max();

        [Benchmark]
        public int Sum() => _items.Sum();

        [Benchmark]
        public void MinList() => _items2.Min();

        [Benchmark]
        public void MaxList() => _items2.Max();

        [Benchmark]
        public int SumList() => _items2.Sum();
    }
}
