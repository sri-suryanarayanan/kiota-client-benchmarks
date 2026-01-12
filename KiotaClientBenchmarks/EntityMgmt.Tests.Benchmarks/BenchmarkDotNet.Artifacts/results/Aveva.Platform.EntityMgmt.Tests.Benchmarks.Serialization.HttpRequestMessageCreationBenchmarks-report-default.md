
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4


 Method                                    | Mean         | Error       | StdDev      | Ratio         | RatioSD | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
------------------------------------------ |-------------:|------------:|------------:|--------------:|--------:|-----:|-------:|-------:|----------:|------------:|
 'GET Entity - Manual HttpRequestMessage'  |     156.2 ns |     3.19 ns |     7.13 ns |             ? |       ? |    1 | 0.0234 |      - |     296 B |           ? |
 'GET Entity - Kiota Request Builder'      |     943.3 ns |    18.10 ns |    24.17 ns |             ? |       ? |    2 | 0.2060 |      - |    2592 B |           ? |
                                           |              |             |             |               |         |      |        |        |           |             |
 'POST with Headers - Manual'              |  16,443.0 ns |   328.09 ns |   322.23 ns |             ? |       ? |    1 | 1.2512 | 0.0305 |   15880 B |           ? |
 'POST with Headers - Kiota'               | 151,771.0 ns | 2,985.34 ns | 4,735.06 ns |             ? |       ? |    2 | 2.4414 |      - |   35055 B |           ? |
                                           |              |             |             |               |         |      |        |        |           |             |
 'POST Bulk - Manual HttpRequestMessage'   |  12,956.9 ns |   186.62 ns |   174.56 ns |             ? |       ? |    1 | 0.7477 |      - |    9392 B |           ? |
 'POST Bulk - Kiota Request Builder'       |  89,403.4 ns | 1,728.26 ns | 2,365.66 ns |             ? |       ? |    2 | 1.4648 |      - |   20857 B |           ? |
                                           |              |             |             |               |         |      |        |        |           |             |
 'POST Entity - Manual HttpRequestMessage' |  14,547.5 ns |   238.28 ns |   211.22 ns |      baseline |         |    1 | 1.2360 | 0.0305 |   15680 B |             |
 'POST Entity - Kiota Request Builder'     | 146,424.4 ns | 2,448.79 ns | 2,170.79 ns | 10.07x slower |   0.20x |    2 | 2.4414 |      - |   34231 B |  2.18x more |
                                           |              |             |             |               |         |      |        |        |           |             |
 'PUT Entity - Manual HttpRequestMessage'  |  14,754.3 ns |   279.57 ns |   310.75 ns |             ? |       ? |    1 | 1.2512 | 0.0610 |   15848 B |           ? |
 'PUT Entity - Kiota Request Builder'      | 147,056.5 ns | 2,714.85 ns | 2,539.47 ns |             ? |       ? |    2 | 2.4414 |      - |   34727 B |           ? |
