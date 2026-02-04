
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6491/23H2/2023Update/SunValley3)
Intel Core Ultra 7 165H 3.80GHz, 1 CPU, 22 logical and 16 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3


 Method                                    | Mean        | Error     | StdDev    | Ratio        | RatioSD | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
------------------------------------------ |------------:|----------:|----------:|-------------:|--------:|-----:|-------:|-------:|----------:|------------:|
 'GET Entity - Manual HttpRequestMessage'  |   0.1186 μs | 0.0012 μs | 0.0010 μs |     baseline |         |    1 | 0.0234 |      - |     296 B |             |
 'GET Entity - Kiota Request Builder'      |   0.6988 μs | 0.0096 μs | 0.0089 μs | 5.89x slower |   0.09x |    2 | 0.2060 | 0.0010 |    2592 B |  8.76x more |
                                           |             |           |           |              |         |      |        |        |           |             |
 'POST with Headers - Manual'              |  10.8782 μs | 0.1102 μs | 0.0977 μs |     baseline |         |    1 | 1.2512 | 0.0305 |   15880 B |             |
 'POST with Headers - Kiota'               | 100.8466 μs | 1.2335 μs | 1.0935 μs | 9.27x slower |   0.13x |    2 | 1.4648 | 0.4883 |   19044 B |  1.20x more |
                                           |             |           |           |              |         |      |        |        |           |             |
 'POST Bulk - Manual HttpRequestMessage'   |   9.0930 μs | 0.1402 μs | 0.1500 μs |     baseline |         |    1 | 0.7477 |      - |    9392 B |             |
 'POST Bulk - Kiota Request Builder'       |  57.7277 μs | 1.0548 μs | 0.9867 μs | 6.35x slower |   0.15x |    2 | 0.9766 | 0.2441 |   12703 B |  1.35x more |
                                           |             |           |           |              |         |      |        |        |           |             |
 'POST Entity - Manual HttpRequestMessage' |  10.6901 μs | 0.1160 μs | 0.1085 μs |     baseline |         |    1 | 1.2360 | 0.0305 |   15680 B |             |
 'POST Entity - Kiota Request Builder'     | 100.3737 μs | 0.6792 μs | 0.5672 μs | 9.39x slower |   0.11x |    2 | 0.9766 |      - |   18027 B |  1.15x more |
                                           |             |           |           |              |         |      |        |        |           |             |
 'PUT Entity - Manual HttpRequestMessage'  |  10.6803 μs | 0.1218 μs | 0.1017 μs |     baseline |         |    1 | 1.2512 | 0.0610 |   15848 B |             |
 'PUT Entity - Kiota Request Builder'      |  97.7994 μs | 0.9946 μs | 0.8817 μs | 9.16x slower |   0.12x |    2 | 0.9766 |      - |   18202 B |  1.15x more |
