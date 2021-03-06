﻿using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [CoreJob]
    [MemoryDiagnoser]
    [RPlotExporter, RankColumn]
    public class ArrayCopyVsBufferBlockCopy
    {
        private readonly byte[] _compressedBlock   = new byte[65536];
        private readonly byte[] _uncompressedBlock = new byte[65536];
        private const int CopyLength               = 30000;

        [GlobalSetup]
        public void Setup() {}

        [Benchmark]
        public void ArrayCopy() => Array.Copy(_uncompressedBlock, 10, _compressedBlock, 10000, CopyLength);

        [Benchmark]
        public void BufferBlockCopy() => Buffer.BlockCopy(_uncompressedBlock, 10, _compressedBlock, 10000, CopyLength);
    }
}