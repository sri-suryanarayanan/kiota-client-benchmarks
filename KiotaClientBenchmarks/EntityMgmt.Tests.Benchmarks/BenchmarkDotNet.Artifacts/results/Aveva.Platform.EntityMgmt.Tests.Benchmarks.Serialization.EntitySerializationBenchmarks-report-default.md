
BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v4


 Method                                   | Mean       | Error      | StdDev     | Rank | Gen0    | Gen1   | Allocated |
----------------------------------------- |-----------:|-----------:|-----------:|-----:|--------:|-------:|----------:|
 'Bulk Entities (10) - System.Text.Json'  |  12.728 μs |  0.2400 μs |  0.2357 μs |    1 |  0.5035 |      - |    6480 B |
 'Bulk Entities (10) - Kiota'             |  87.268 μs |  1.5409 μs |  2.0571 μs |    2 |  2.6855 |      - |   34708 B |
                                          |            |            |            |      |         |        |           |
 'Bulk Entities (100) - System.Text.Json' | 134.189 μs |  2.6165 μs |  3.2133 μs |    1 |  4.3945 |      - |   56520 B |
 'Bulk Entities (100) - Kiota'            | 860.670 μs | 12.8460 μs | 12.0162 μs |    2 | 21.4844 | 3.9063 |  274349 B |
                                          |            |            |            |      |         |        |           |
 'Complex Entity - System.Text.Json'      |  19.963 μs |  0.3950 μs |  0.5272 μs |    1 |  1.2207 |      - |   15488 B |
 'Complex Entity - Kiota'                 | 212.518 μs |  4.1355 μs |  4.0616 μs |    2 |  8.3008 | 0.4883 |  108059 B |
                                          |            |            |            |      |         |        |           |
 'Simple Entity - System.Text.Json'       |   1.498 μs |  0.0297 μs |  0.0426 μs |    1 |  0.0706 |      - |     888 B |
 'Simple Entity - Kiota'                  |   9.472 μs |  0.0973 μs |  0.0760 μs |    2 |  0.4883 |      - |    6450 B |
