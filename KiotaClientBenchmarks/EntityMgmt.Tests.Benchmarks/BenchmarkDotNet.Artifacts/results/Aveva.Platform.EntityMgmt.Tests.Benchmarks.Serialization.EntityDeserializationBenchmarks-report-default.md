
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4


 Method                                   | Mean         | Error      | StdDev     | Rank | Gen0     | Gen1    | Allocated  |
----------------------------------------- |-------------:|-----------:|-----------:|-----:|---------:|--------:|-----------:|
 'Bulk Entities (10) - System.Text.Json'  |    24.749 μs |  0.4921 μs |  0.4833 μs |    1 |   0.7324 |       - |    9.21 KB |
 'Bulk Entities (10) - Kiota'             |   292.315 μs |  5.8268 μs |  5.7227 μs |    2 |  10.7422 |       - |  134.53 KB |
                                          |              |            |            |      |          |         |            |
 'Bulk Entities (100) - System.Text.Json' |   238.725 μs |  4.5641 μs |  4.2692 μs |    1 |   6.3477 |  1.4648 |   79.94 KB |
 'Bulk Entities (100) - Kiota'            | 3,017.245 μs | 51.6735 μs | 43.1497 μs |    2 | 101.5625 | 31.2500 | 1275.87 KB |
                                          |              |            |            |      |          |         |            |
 'Complex Entity - System.Text.Json'      |    41.035 μs |  0.7070 μs |  0.5904 μs |    1 |   1.3428 |  0.0610 |   16.92 KB |
 'Complex Entity - Kiota'                 |   747.792 μs | 14.7822 μs | 12.3438 μs |    2 |  23.4375 |  1.9531 |  288.71 KB |
                                          |              |            |            |      |          |         |            |
 'EntityResponse - System.Text.Json'      |    42.400 μs |  0.7327 μs |  0.6495 μs |    1 |   1.3428 |  0.0610 |      17 KB |
 'EntityResponse - Kiota'                 |   779.237 μs | 14.6026 μs | 18.9875 μs |    2 |  23.4375 |  1.9531 |  289.88 KB |
                                          |              |            |            |      |          |         |            |
 'Simple Entity - System.Text.Json'       |     2.616 μs |  0.0474 μs |  0.0665 μs |    1 |   0.0954 |       - |    1.21 KB |
 'Simple Entity - Kiota'                  |    31.457 μs |  0.5799 μs |  0.6903 μs |    2 |   1.4648 |       - |   18.33 KB |
