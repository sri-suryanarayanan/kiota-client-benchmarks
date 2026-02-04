
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6491/23H2/2023Update/SunValley3)
Intel Core Ultra 7 165H 3.80GHz, 1 CPU, 22 logical and 16 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3


 Method                                    | Mean       | Error      | StdDev     | Median     | Ratio         | RatioSD | Rank | Gen0    | Gen1   | Allocated | Alloc Ratio |
------------------------------------------ |-----------:|-----------:|-----------:|-----------:|--------------:|--------:|-----:|--------:|-------:|----------:|------------:|
 'Bulk(10) - System.Text.Json'             |   9.847 μs |  0.2399 μs |  0.6960 μs |   9.821 μs |      baseline |         |    1 |  0.5035 |      - |    6480 B |             |
 'Bulk(10) - Kiota (Standard)'             |  60.676 μs |  1.2085 μs |  3.2048 μs |  59.050 μs |  6.19x slower |   0.54x |    2 |  1.9531 |      - |   26481 B |  4.09x more |
 'Bulk(10) - Kiota (writer only)'          |  59.226 μs |  1.1842 μs |  2.0109 μs |  58.570 μs |  6.04x slower |   0.46x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
 'Bulk(10) - Kiota (with writer factory)'  |  61.215 μs |  1.2232 μs |  3.2648 μs |  61.612 μs |  6.25x slower |   0.54x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
                                           |            |            |            |            |               |         |      |         |        |           |             |
 'Bulk(100) - System.Text.Json'            |  95.073 μs |  1.9581 μs |  5.6807 μs |  94.883 μs |      baseline |         |    1 |  4.3945 |      - |   56520 B |             |
 'Bulk(100) - Kiota (Standard)'            | 587.662 μs | 11.6546 μs | 30.4980 μs | 572.386 μs |  6.20x slower |   0.49x |    2 | 15.6250 | 1.9531 |  208677 B |  3.69x more |
 'Bulk(100) - Kiota (writer only)'         | 568.112 μs |  8.5177 μs |  7.1127 μs | 565.403 μs |  6.00x slower |   0.36x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
 'Bulk(100) - Kiota (with writer factory)' | 601.579 μs | 11.9991 μs | 28.5172 μs | 609.045 μs |  6.35x slower |   0.48x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
                                           |            |            |            |            |               |         |      |         |        |           |             |
 'Complex - System.Text.Json'              |  15.705 μs |  0.3117 μs |  0.7819 μs |  15.627 μs |      baseline |         |    1 |  1.2207 |      - |   15488 B |             |
 'Complex - Kiota (Standard)'              | 153.604 μs |  4.1239 μs | 11.9643 μs | 148.304 μs |  9.80x slower |   0.90x |    3 |  5.8594 | 0.4883 |   76182 B |  4.92x more |
 'Complex - Kiota (writer only)'           | 139.715 μs |  1.5910 μs |  1.3285 μs | 139.265 μs |  8.92x slower |   0.45x |    2 |  5.8594 | 0.4883 |   74830 B |  4.83x more |
 'Complex - Kiota (with writer factory)'   | 159.811 μs |  3.8024 μs | 11.2113 μs | 161.228 μs | 10.20x slower |   0.87x |    3 |  5.8594 |      - |   75388 B |  4.87x more |
                                           |            |            |            |            |               |         |      |         |        |           |             |
 'Simple - System.Text.Json'               |   1.029 μs |  0.0215 μs |  0.0614 μs |   1.030 μs |      baseline |         |    1 |  0.0706 |      - |     888 B |             |
 'Simple - Kiota (Standard)'               |   7.072 μs |  0.1360 μs |  0.1907 μs |   7.076 μs |  6.90x slower |   0.45x |    2 |  0.4578 |      - |    6002 B |  6.76x more |
 'Simple - Kiota (writer only)'            |   6.782 μs |  0.1344 μs |  0.3347 μs |   6.865 μs |  6.62x slower |   0.51x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
 'Simple - Kiota (with writer factory)'    |   6.857 μs |  0.1324 μs |  0.2849 μs |   6.887 μs |  6.69x slower |   0.49x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
