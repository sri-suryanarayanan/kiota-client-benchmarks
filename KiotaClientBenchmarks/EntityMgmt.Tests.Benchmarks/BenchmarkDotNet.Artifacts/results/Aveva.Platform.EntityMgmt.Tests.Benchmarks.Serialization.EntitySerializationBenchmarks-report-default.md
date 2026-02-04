
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6491/23H2/2023Update/SunValley3)
Intel Core Ultra 7 165H 3.80GHz, 1 CPU, 22 logical and 16 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3


 Method                                    | Mean        | Error     | StdDev    | Ratio         | RatioSD | Rank | Gen0    | Gen1   | Allocated | Alloc Ratio |
------------------------------------------ |------------:|----------:|----------:|--------------:|--------:|-----:|--------:|-------:|----------:|------------:|
 'Bulk(10) - System.Text.Json'             |   9.6281 μs | 0.1913 μs | 0.4317 μs |      baseline |         |    1 |  0.5035 |      - |    6480 B |             |
 'Bulk(10) - Kiota (Standard)'             |  62.8119 μs | 1.2489 μs | 2.7933 μs |  6.54x slower |   0.42x |    2 |  1.9531 |      - |   26481 B |  4.09x more |
 'Bulk(10) - Kiota (writer only)'          |  59.9785 μs | 1.1936 μs | 2.5949 μs |  6.24x slower |   0.40x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
 'Bulk(10) - Kiota (with writer factory)'  |  62.8224 μs | 1.2460 μs | 3.1716 μs |  6.54x slower |   0.45x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
                                           |             |           |           |               |         |      |         |        |           |             |
 'Bulk(100) - System.Text.Json'            |  88.0523 μs | 1.7533 μs | 4.9452 μs |      baseline |         |    1 |  4.3945 |      - |   56520 B |             |
 'Bulk(100) - Kiota (Standard)'            | 550.4064 μs | 4.9952 μs | 4.6726 μs |  6.27x slower |   0.34x |    2 | 15.6250 | 1.9531 |  208677 B |  3.69x more |
 'Bulk(100) - Kiota (writer only)'         | 553.4926 μs | 3.3655 μs | 2.8104 μs |  6.30x slower |   0.34x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
 'Bulk(100) - Kiota (with writer factory)' | 561.3661 μs | 4.4770 μs | 3.9687 μs |  6.39x slower |   0.35x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
                                           |             |           |           |               |         |      |         |        |           |             |
 'Complex - System.Text.Json'              |  14.3527 μs | 0.2783 μs | 0.3418 μs |      baseline |         |    1 |  1.2207 |      - |   15488 B |             |
 'Complex - Kiota (Standard)'              | 137.8317 μs | 1.0692 μs | 1.0001 μs |  9.61x slower |   0.23x |    2 |  5.8594 | 0.4883 |   74462 B |  4.81x more |
 'Complex - Kiota (writer only)'           | 145.7958 μs | 1.4405 μs | 1.3474 μs | 10.16x slower |   0.25x |    2 |  5.8594 |      - |   77068 B |  4.98x more |
 'Complex - Kiota (with writer factory)'   | 141.8846 μs | 1.7645 μs | 1.6505 μs |  9.89x slower |   0.25x |    2 |  5.8594 |      - |   75180 B |  4.85x more |
                                           |             |           |           |               |         |      |         |        |           |             |
 'Simple - System.Text.Json'               |   0.9545 μs | 0.0177 μs | 0.0218 μs |      baseline |         |    1 |  0.0706 |      - |     888 B |             |
 'Simple - Kiota (Standard)'               |   6.2723 μs | 0.0700 μs | 0.0585 μs |  6.57x slower |   0.16x |    2 |  0.4578 |      - |    6002 B |  6.76x more |
 'Simple - Kiota (writer only)'            |   6.3293 μs | 0.1210 μs | 0.1072 μs |  6.63x slower |   0.18x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
 'Simple - Kiota (with writer factory)'    |   6.2891 μs | 0.1215 μs | 0.1136 μs |  6.59x slower |   0.19x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
