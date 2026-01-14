
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4


 Method                                    | Mean         | Error       | StdDev      | Median       | Ratio         | RatioSD | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
------------------------------------------ |-------------:|------------:|------------:|-------------:|--------------:|--------:|-----:|-------:|-------:|----------:|------------:|
 'GET Entity - Manual HttpRequestMessage'  |     173.4 ns |     3.51 ns |     3.11 ns |     172.8 ns |      baseline |         |    1 | 0.0234 |      - |     296 B |             |
 'GET Entity - Kiota Request Builder'      |   1,019.6 ns |    17.05 ns |    28.02 ns |   1,016.7 ns |  5.88x slower |   0.19x |    2 | 0.2060 |      - |    2592 B |  8.76x more |
                                           |              |             |             |              |               |         |      |        |        |           |             |
 'POST with Headers - Manual'              |  15,619.6 ns |   159.30 ns |   149.01 ns |  15,656.2 ns |      baseline |         |    1 | 1.2512 | 0.0305 |   15880 B |             |
 'POST with Headers - Kiota'               | 147,585.5 ns | 2,838.03 ns | 3,589.19 ns | 148,216.7 ns |  9.45x slower |   0.24x |    2 | 2.4414 |      - |   35175 B |  2.22x more |
                                           |              |             |             |              |               |         |      |        |        |           |             |
 'POST Bulk - Manual HttpRequestMessage'   |  14,494.8 ns |   288.05 ns |   422.22 ns |  14,527.5 ns |      baseline |         |    1 | 0.7324 |      - |    9392 B |             |
 'POST Bulk - Kiota Request Builder'       |  86,893.6 ns | 1,698.95 ns | 2,436.58 ns |  87,205.7 ns |  6.00x slower |   0.24x |    2 | 1.4648 |      - |   20857 B |  2.22x more |
                                           |              |             |             |              |               |         |      |        |        |           |             |
 'POST Entity - Manual HttpRequestMessage' |  15,088.8 ns |   566.23 ns | 1,651.73 ns |  14,278.3 ns |      baseline |         |    1 | 1.2207 | 0.0305 |   15680 B |             |
 'POST Entity - Kiota Request Builder'     | 158,353.1 ns | 3,017.37 ns | 6,495.21 ns | 157,836.1 ns | 10.61x slower |   1.13x |    2 | 2.4414 |      - |   34391 B |  2.19x more |
                                           |              |             |             |              |               |         |      |        |        |           |             |
 'PUT Entity - Manual HttpRequestMessage'  |  16,955.2 ns |   296.17 ns |   277.04 ns |  16,968.2 ns |      baseline |         |    1 | 1.2512 | 0.0610 |   15848 B |             |
 'PUT Entity - Kiota Request Builder'      | 157,385.6 ns | 2,995.91 ns | 5,627.05 ns | 155,750.9 ns |  9.28x slower |   0.36x |    2 | 2.4414 |      - |   34375 B |  2.17x more |
