
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4


 Method                                       | Mean       | Error      | StdDev     | Median     | Ratio         | RatioSD | Rank | Gen0    | Gen1   | Allocated | Alloc Ratio |
--------------------------------------------- |-----------:|-----------:|-----------:|-----------:|--------------:|--------:|-----:|--------:|-------:|----------:|------------:|
 'Bulk(10) - System.Text.Json'                |  12.993 μs |  0.2471 μs |  0.6466 μs |  12.794 μs |      baseline |         |    2 |  0.5035 |      - |    6480 B |             |
 'Bulk(10) - Kiota (Standard)'                |  93.112 μs |  1.5487 μs |  1.3729 μs |  92.827 μs |  7.18x slower |   0.36x |    3 |  2.6855 |      - |   34708 B |  5.36x more |
 'Bulk(10) - Kiota (RecyclableMemoryStream)'  |  12.109 μs |  0.2416 μs |  0.3761 μs |  12.169 μs |  1.07x faster |   0.06x |    1 |  2.0294 | 0.0610 |   25637 B |  3.96x more |
 'Bulk(10) - Kiota (ArrayPool)'               |  11.470 μs |  0.2253 μs |  0.3508 μs |  11.525 μs |  1.13x faster |   0.07x |    1 |  2.1973 | 0.1526 |   27701 B |  4.27x more |
                                              |            |            |            |            |               |         |      |         |        |           |             |
 'Bulk(100) - System.Text.Json'               | 122.928 μs |  2.3075 μs |  2.0455 μs | 122.502 μs |      baseline |         |    1 |  4.3945 |      - |   56520 B |             |
 'Bulk(100) - Kiota (Standard)'               | 864.296 μs | 16.8412 μs | 22.4825 μs | 865.670 μs |  7.03x slower |   0.21x |    2 | 21.4844 | 3.9063 |  274349 B |  4.85x more |
 'Bulk(100) - Kiota (RecyclableMemoryStream)' | 116.021 μs |  2.3097 μs |  3.9841 μs | 116.089 μs |  1.06x faster |   0.04x |    1 | 15.9912 | 3.4180 |  201693 B |  3.57x more |
 'Bulk(100) - Kiota (ArrayPool)'              | 117.775 μs |  1.4249 μs |  1.1125 μs | 117.867 μs |  1.04x faster |   0.02x |    1 | 19.2871 | 3.9063 |  243317 B |  4.30x more |
                                              |            |            |            |            |               |         |      |         |        |           |             |
 'Complex - System.Text.Json'                 |  20.611 μs |  0.3111 μs |  0.2910 μs |  20.585 μs |      baseline |         |    1 |  1.2207 |      - |   15488 B |             |
 'Complex - Kiota (Standard)'                 | 219.584 μs |  3.1830 μs |  2.8216 μs | 220.367 μs | 10.66x slower |   0.20x |    4 |  8.3008 | 0.4883 |  107035 B |  6.91x more |
 'Complex - Kiota (RecyclableMemoryStream)'   |  30.335 μs |  0.5954 μs |  1.0271 μs |  30.619 μs |  1.47x slower |   0.05x |    2 |  6.2256 | 0.6104 |   78902 B |  5.09x more |
 'Complex - Kiota (ArrayPool)'                |  32.584 μs |  0.6066 μs |  1.1541 μs |  32.576 μs |  1.58x slower |   0.06x |    3 |  7.9956 | 0.9766 |  100586 B |  6.49x more |
                                              |            |            |            |            |               |         |      |         |        |           |             |
 'Simple - System.Text.Json'                  |   1.406 μs |  0.0270 μs |  0.0352 μs |   1.414 μs |      baseline |         |    1 |  0.0706 |      - |     888 B |             |
 'Simple - Kiota (Standard)'                  |   9.421 μs |  0.1818 μs |  0.1611 μs |   9.388 μs |  6.70x slower |   0.20x |    3 |  0.4883 |      - |    6450 B |  7.26x more |
 'Simple - Kiota (RecyclableMemoryStream)'    |   1.930 μs |  0.0379 μs |  0.0555 μs |   1.928 μs |  1.37x slower |   0.05x |    2 |  0.8049 | 0.0191 |   10122 B | 11.40x more |
 'Simple - Kiota (ArrayPool)'                 |   1.831 μs |  0.0239 μs |  0.0212 μs |   1.830 μs |  1.30x slower |   0.04x |    2 |  0.7954 |      - |    9986 B | 11.25x more |
