using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [CoreJob]
    [MemoryDiagnoser]
    [RPlotExporter, RankColumn]
    public class ForVsForEach
    {
        private const int N = 300;
        private readonly int[] _data;

        public ForVsForEach()
        {
            _data = new int[N];
            for (var i = 0; i < N; i++) _data[i] = i;
        }

        [GlobalSetup]
        public void Setup() {}

        [Benchmark]
        public int ForLoop()
        {
            var sum = 0;
            for (var i = 0; i < N; i++) sum += _data[i];
            return sum;
        }

        [Benchmark]
        public int ForLoopWithLength()
        {
            var sum = 0;
            for (var i = 0; i < _data.Length; i++) sum += _data[i];
            return sum;
        }

        [Benchmark]
        public int ForEachLoop()
        {
            var sum = 0;
            foreach (int t in _data) sum += t;
            return sum;
        }

        [Benchmark]
        public int Linq() => _data.Sum();
    }
}