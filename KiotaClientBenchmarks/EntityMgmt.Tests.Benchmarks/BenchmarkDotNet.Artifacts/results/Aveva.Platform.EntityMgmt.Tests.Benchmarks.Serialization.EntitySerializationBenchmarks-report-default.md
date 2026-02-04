
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6491/23H2/2023Update/SunValley3)
Intel Core Ultra 7 165H 3.80GHz, 1 CPU, 22 logical and 16 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3


 Method                                    | Mean        | Error     | StdDev    | Ratio        | RatioSD | Rank | Gen0    | Gen1   | Allocated | Alloc Ratio |
------------------------------------------ |------------:|----------:|----------:|-------------:|--------:|-----:|--------:|-------:|----------:|------------:|
 'Bulk(10) - System.Text.Json'             |   8.8902 μs | 0.1255 μs | 0.1174 μs |     baseline |         |    1 |  0.5035 |      - |    6480 B |             |
 'Bulk(10) - Kiota (Standard)'             |  58.4654 μs | 1.1387 μs | 1.1694 μs | 6.58x slower |   0.15x |    2 |  1.9531 |      - |   26481 B |  4.09x more |
 'Bulk(10) - Kiota (writer only)'          |  57.0227 μs | 0.4343 μs | 0.4063 μs | 6.42x slower |   0.09x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
 'Bulk(10) - Kiota (with writer factory)'  |  57.1546 μs | 0.3946 μs | 0.3691 μs | 6.43x slower |   0.09x |    2 |  1.9531 |      - |   26273 B |  4.05x more |
                                           |             |           |           |              |         |      |         |        |           |             |
 'Bulk(100) - System.Text.Json'            |  83.5314 μs | 0.9185 μs | 0.8142 μs |     baseline |         |    1 |  4.3945 |      - |   56520 B |             |
 'Bulk(100) - Kiota (Standard)'            | 562.0079 μs | 5.5754 μs | 4.9425 μs | 6.73x slower |   0.09x |    2 | 15.6250 | 1.9531 |  208677 B |  3.69x more |
 'Bulk(100) - Kiota (writer only)'         | 556.9839 μs | 6.6773 μs | 5.9193 μs | 6.67x slower |   0.09x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
 'Bulk(100) - Kiota (with writer factory)' | 563.5038 μs | 6.6945 μs | 5.9345 μs | 6.75x slower |   0.09x |    2 | 15.6250 |      - |  208460 B |  3.69x more |
                                           |             |           |           |              |         |      |         |        |           |             |
 'Complex - System.Text.Json'              |  14.5556 μs | 0.2200 μs | 0.2058 μs |     baseline |         |    1 |  1.2207 |      - |   15488 B |             |
 'Complex - Kiota (Standard)'              | 142.8103 μs | 1.8028 μs | 1.6863 μs | 9.81x slower |   0.17x |    2 |  5.8594 | 0.4883 |   76694 B |  4.95x more |
 'Complex - Kiota (writer only)'           | 137.4822 μs | 2.5106 μs | 2.3484 μs | 9.45x slower |   0.20x |    2 |  5.3711 |      - |   73206 B |  4.73x more |
 'Complex - Kiota (with writer factory)'   | 142.7293 μs | 1.4350 μs | 1.3423 μs | 9.81x slower |   0.16x |    2 |  5.8594 |      - |   75740 B |  4.89x more |
                                           |             |           |           |              |         |      |         |        |           |             |
 'Simple - System.Text.Json'               |   0.9107 μs | 0.0173 μs | 0.0206 μs |     baseline |         |    1 |  0.0706 |      - |     888 B |             |
 'Simple - Kiota (Standard)'               |   6.3919 μs | 0.0571 μs | 0.0534 μs | 7.02x slower |   0.17x |    2 |  0.4578 |      - |    6002 B |  6.76x more |
 'Simple - Kiota (writer only)'            |   6.2727 μs | 0.0748 μs | 0.0700 μs | 6.89x slower |   0.17x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
 'Simple - Kiota (with writer factory)'    |   6.2620 μs | 0.0636 μs | 0.0564 μs | 6.88x slower |   0.17x |    2 |  0.4578 |      - |    5794 B |  6.52x more |
