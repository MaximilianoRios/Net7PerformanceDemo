using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace LinqPerformance
{
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        [Params(100)]
        public int Size { get; set; }

        private IEnumerable<int> _items;

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(1, Size).ToArray();
        }

        [Benchmark]
        public void Min() => _items.Min();

        [Benchmark]
        public void Max() => _items.Max();

        [Benchmark]
        public int Sum() => _items.Sum();

        [Benchmark]
        public int Max_Own()
        {
            var biggest = int.MinValue;
            foreach(var item in _items)
            {
                biggest = item;
            }
            return biggest;
        }
    }
}
