
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6491/23H2/2023Update/SunValley3)
Intel Core Ultra 7 165H 3.80GHz, 1 CPU, 22 logical and 16 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3


 Method                                   | Mean         | Error      | StdDev     | Ratio         | RatioSD | Rank | Gen0     | Gen1    | Allocated  | Alloc Ratio |
----------------------------------------- |-------------:|-----------:|-----------:|--------------:|--------:|-----:|---------:|--------:|-----------:|------------:|
 'Bulk Entities (10) - System.Text.Json'  |    15.652 μs |  0.2361 μs |  0.2209 μs |      baseline |         |    1 |   0.7324 |       - |    9.21 KB |             |
 'Bulk Entities (10) - Kiota'             |   196.798 μs |  3.9123 μs |  5.4845 μs | 12.58x slower |   0.39x |    2 |  10.7422 |  0.4883 |  134.52 KB | 14.61x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'Bulk Entities (100) - System.Text.Json' |   159.258 μs |  3.1594 μs |  6.4539 μs |      baseline |         |    1 |   6.3477 |  1.4648 |   79.94 KB |             |
 'Bulk Entities (100) - Kiota'            | 2,043.877 μs | 40.7341 μs | 93.5933 μs | 12.85x slower |   0.79x |    2 | 101.5625 | 31.2500 | 1275.87 KB | 15.96x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'Complex Entity - System.Text.Json'      |    28.219 μs |  0.5628 μs |  1.5500 μs |      baseline |         |    1 |   1.3428 |  0.0610 |   16.92 KB |             |
 'Complex Entity - Kiota'                 |   455.758 μs |  5.3695 μs |  4.4838 μs | 16.20x slower |   0.87x |    2 |  23.4375 |  1.9531 |  288.71 KB | 17.06x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'EntityResponse - System.Text.Json'      |    26.299 μs |  0.5221 μs |  0.9933 μs |      baseline |         |    1 |   1.3733 |  0.0610 |      17 KB |             |
 'EntityResponse - Kiota'                 |   501.864 μs |  9.9281 μs | 18.8893 μs | 19.11x slower |   1.00x |    2 |  23.4375 |  1.9531 |  289.88 KB | 17.05x more |
                                          |              |            |            |               |         |      |          |         |            |             |
 'Simple Entity - System.Text.Json'       |     1.544 μs |  0.0180 μs |  0.0141 μs |      baseline |         |    1 |   0.0973 |       - |    1.21 KB |             |
 'Simple Entity - Kiota'                  |    21.012 μs |  0.4197 μs |  0.9727 μs | 13.61x slower |   0.64x |    2 |   1.4648 |       - |   18.33 KB | 15.14x more |
