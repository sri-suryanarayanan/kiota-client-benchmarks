
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4


 Method                                   | Mean         | Error      | StdDev     | Ratio         | RatioSD | Rank | Gen0     | Gen1    | Allocated  | Alloc Ratio |
----------------------------------------- |-------------:|-----------:|-----------:|--------------:|--------:|-----:|---------:|--------:|-----------:|------------:|
 'Bulk Entities (10) - System.Text.Json'  |    25.437 μs |  0.5046 μs |  0.8969 μs |      baseline |         |    1 |   0.7324 |       - |    9.21 KB |             |
 'Bulk Entities (10) - Kiota'             |   313.185 μs |  6.1628 μs | 10.2966 μs | 12.33x slower |   0.58x |    2 |  10.7422 |       - |  134.53 KB | 14.61x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'Bulk Entities (100) - System.Text.Json' |   244.673 μs |  3.2935 μs |  2.9196 μs |      baseline |         |    1 |   6.3477 |  1.4648 |   79.95 KB |             |
 'Bulk Entities (100) - Kiota'            | 3,096.147 μs | 59.0857 μs | 93.7162 μs | 12.66x slower |   0.41x |    2 | 101.5625 | 31.2500 | 1275.87 KB | 15.96x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'Complex Entity - System.Text.Json'      |    41.645 μs |  0.8292 μs |  1.7490 μs |      baseline |         |    1 |   1.3428 |  0.0610 |   16.92 KB |             |
 'Complex Entity - Kiota'                 |   736.499 μs | 14.3699 μs | 15.9721 μs | 17.72x slower |   0.81x |    2 |  23.4375 |  1.9531 |  288.71 KB | 17.06x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'EntityResponse - System.Text.Json'      |    38.556 μs |  0.7444 μs |  0.9142 μs |      baseline |         |    1 |   1.3428 |  0.0610 |      17 KB |             |
 'EntityResponse - Kiota'                 |   722.230 μs | 14.6558 μs | 12.9920 μs | 18.74x slower |   0.55x |    2 |  23.4375 |  1.9531 |  289.88 KB | 17.05x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'Simple Entity - System.Text.Json'       |     2.454 μs |  0.0468 μs |  0.0501 μs |      baseline |         |    1 |   0.0954 |       - |    1.21 KB |             |
 'Simple Entity - Kiota'                  |    30.721 μs |  0.5648 μs |  0.4716 μs | 12.52x slower |   0.31x |    2 |   1.4648 |       - |   18.33 KB | 15.14x more |
