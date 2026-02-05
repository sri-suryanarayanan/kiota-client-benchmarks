
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6491/23H2/2023Update/SunValley3)
Intel Core Ultra 7 165H 3.80GHz, 1 CPU, 22 logical and 16 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3


 Method                                    | Mean        | Error     | StdDev     | Median      | Ratio         | RatioSD | Rank | Gen0    | Gen1   | Allocated | Alloc Ratio |
------------------------------------------ |------------:|----------:|-----------:|------------:|--------------:|--------:|-----:|--------:|-------:|----------:|------------:|
 'Bulk(10) - System.Text.Json'             |   9.2239 μs | 0.1722 μs |  0.4446 μs |   9.0599 μs |      baseline |         |    1 |  0.5035 |      - |    6480 B |             |
 'Bulk(10) - Kiota (Standard)'             |  63.4612 μs | 1.5994 μs |  4.7160 μs |  64.1523 μs |  6.90x slower |   0.60x |    2 |  1.9531 |      - |   26553 B |  4.10x more |
 'Bulk(10) - Kiota (writer only)'          |  62.9036 μs | 0.8284 μs |  0.7343 μs |  63.0005 μs |  6.83x slower |   0.32x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
 'Bulk(10) - Kiota (with writer factory)'  |  63.4807 μs | 1.2612 μs |  1.9260 μs |  63.3822 μs |  6.90x slower |   0.38x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
                                           |             |           |            |             |               |         |      |         |        |           |             |
 'Bulk(100) - System.Text.Json'            |  86.8592 μs | 1.7257 μs |  4.4546 μs |  85.0017 μs |      baseline |         |    1 |  4.3945 |      - |   56520 B |             |
 'Bulk(100) - Kiota (Standard)'            | 570.5964 μs | 5.2255 μs |  4.6323 μs | 570.9902 μs |  6.59x slower |   0.33x |    2 | 15.6250 | 1.9531 |  208749 B |  3.69x more |
 'Bulk(100) - Kiota (writer only)'         | 577.4059 μs | 7.4644 μs |  6.2331 μs | 575.1330 μs |  6.66x slower |   0.34x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
 'Bulk(100) - Kiota (with writer factory)' | 566.1126 μs | 4.0819 μs |  3.4085 μs | 566.6541 μs |  6.53x slower |   0.32x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
                                           |             |           |            |             |               |         |      |         |        |           |             |
 'Complex - System.Text.Json'              |  14.2205 μs | 0.2452 μs |  0.2624 μs |  14.1749 μs |      baseline |         |    1 |  1.2207 |      - |   15488 B |             |
 'Complex - Kiota (Standard)'              | 156.0225 μs | 4.4901 μs | 13.2393 μs | 152.8617 μs | 10.98x slower |   0.95x |    2 |  5.8594 | 0.4883 |   75910 B |  4.90x more |
 'Complex - Kiota (writer only)'           | 144.0475 μs | 2.8557 μs |  2.5315 μs | 142.9538 μs | 10.13x slower |   0.25x |    2 |  5.8594 |      - |   74092 B |  4.78x more |
 'Complex - Kiota (with writer factory)'   | 143.7283 μs | 1.6542 μs |  1.2915 μs | 143.9499 μs | 10.11x slower |   0.20x |    2 |  5.8594 |      - |   73908 B |  4.77x more |
                                           |             |           |            |             |               |         |      |         |        |           |             |
 'Simple - System.Text.Json'               |   0.9546 μs | 0.0153 μs |  0.0136 μs |   0.9534 μs |      baseline |         |    1 |  0.0706 |      - |     888 B |             |
 'Simple - Kiota (Standard)'               |   7.3092 μs | 0.2119 μs |  0.6079 μs |   7.2604 μs |  7.66x slower |   0.64x |    2 |  0.4578 |      - |    6074 B |  6.84x more |
 'Simple - Kiota (writer only)'            |   6.6407 μs | 0.1195 μs |  0.1117 μs |   6.6619 μs |  6.96x slower |   0.15x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
 'Simple - Kiota (with writer factory)'    |   6.5708 μs | 0.1255 μs |  0.1587 μs |   6.5594 μs |  6.88x slower |   0.19x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
