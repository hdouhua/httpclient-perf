# benchmark of httpclient

please refer to 

- [You're (probably still) using HttpClient wrong and it is destabilizing your software](https://josef.codes/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/)
- [Using Streams with HttpClient to Improve Performance and Memory Usage](https://code-maze.com/using-streams-with-httpclient-to-improve-performance-and-memory-usage/)

## Benchmark instructions

1. Clone the repository
2. ```cd jos.httpclient```
3. ```dotnet build -c Release```
4. ```dotnet run src/JOS.HttpClient.GitHubDummyApi -c Release```
5. ```cd /src/JOS.HttpClient.Benchmark/bin/Release/netcore```
6. ```dotnet JOS.HttpClient.Benchmark.dll```

You can control how many items the Dummy API should return by changing this parameter:
https://github.com/joseftw/jos.httpclient/blob/develop/src/JOS.HttpClient.GitHubDummyApi/GitHubRepositoriesProvider.cs#L29

## Current benchmarks 2020-08-11

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.388 (2004/?/20H1)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT
  Job-PDBYUI : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT

Runtime=.NET Core 3.1  InvocationCount=50  UnrollFactor=1  
```
### GetAllProjectsQuery
#### 10 items

```
|    Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------- |---------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|  Version0 | 4.458 ms | 0.0795 ms | 0.0705 ms |  1.00 |    0.00 |     - |     - |     - |  74.57 KB |
|  Version1 | 4.515 ms | 0.0730 ms | 0.0683 ms |  1.01 |    0.02 |     - |     - |     - |  74.95 KB |
|  Version2 | 4.308 ms | 0.0628 ms | 0.0588 ms |  0.97 |    0.02 |     - |     - |     - |  58.11 KB |
|  Version3 | 4.303 ms | 0.0650 ms | 0.0608 ms |  0.96 |    0.02 |     - |     - |     - |  59.27 KB |
|  Version4 | 4.315 ms | 0.0632 ms | 0.0591 ms |  0.97 |    0.02 |     - |     - |     - |  59.34 KB |
|  Version5 | 4.394 ms | 0.0636 ms | 0.0563 ms |  0.99 |    0.02 |     - |     - |     - |  59.32 KB |
|  Version6 | 4.310 ms | 0.0747 ms | 0.0698 ms |  0.97 |    0.01 |     - |     - |     - |  53.23 KB |
|  Version7 | 4.309 ms | 0.0748 ms | 0.0700 ms |  0.97 |    0.02 |     - |     - |     - |  44.28 KB |
|  Version8 | 4.291 ms | 0.0577 ms | 0.0539 ms |  0.96 |    0.02 |     - |     - |     - |  44.54 KB |
|  Version9 | 4.349 ms | 0.0591 ms | 0.0524 ms |  0.98 |    0.02 |     - |     - |     - |  27.51 KB |
| Version10 | 4.286 ms | 0.0772 ms | 0.0684 ms |  0.96 |    0.02 |     - |     - |     - |   6.27 KB |
```

#### 100 items

```
|    Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|---------- |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|
|  Version0 | 10.167 ms | 0.0903 ms | 0.0705 ms | 10.169 ms |  1.00 |    0.00 | 80.0000 | 40.0000 | 40.0000 | 499.21 KB |
|  Version1 | 10.192 ms | 0.1677 ms | 0.1309 ms | 10.196 ms |  1.00 |    0.01 | 80.0000 | 40.0000 | 40.0000 | 499.59 KB |
|  Version2 | 16.158 ms | 1.0455 ms | 3.0826 ms | 15.433 ms |  1.21 |    0.10 | 80.0000 | 40.0000 | 40.0000 | 482.75 KB |
|  Version3 | 17.477 ms | 1.0617 ms | 3.1137 ms | 18.146 ms |  1.89 |    0.13 | 80.0000 | 40.0000 | 40.0000 | 483.88 KB |
|  Version4 | 14.450 ms | 0.6694 ms | 1.9526 ms | 14.712 ms |  1.49 |    0.30 | 80.0000 | 40.0000 | 40.0000 | 483.98 KB |
|  Version5 | 13.882 ms | 1.1389 ms | 3.3221 ms | 12.409 ms |  1.73 |    0.31 | 80.0000 | 40.0000 | 40.0000 | 483.96 KB |
|  Version6 | 10.927 ms | 0.2171 ms | 0.2323 ms | 10.875 ms |  1.08 |    0.02 | 80.0000 | 20.0000 | 20.0000 | 396.51 KB |
|  Version7 | 10.588 ms | 0.2115 ms | 0.5718 ms | 10.503 ms |  1.04 |    0.04 | 60.0000 |       - |       - | 306.19 KB |
|  Version8 |  9.765 ms | 0.1472 ms | 0.1305 ms |  9.743 ms |  0.96 |    0.02 | 60.0000 |       - |       - | 309.26 KB |
|  Version9 | 10.244 ms | 0.1845 ms | 0.1725 ms | 10.311 ms |  1.00 |    0.02 |       - |       - |       - |  46.72 KB |
| Version10 |  9.632 ms | 0.1681 ms | 0.1572 ms |  9.589 ms |  0.95 |    0.02 | 40.0000 | 40.0000 | 40.0000 | 143.91 KB |
```
#### 1000 items
```
|    Method |     Mean |    Error |   StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|---------- |---------:|---------:|---------:|------:|--------:|---------:|---------:|---------:|-----------:|
|  Version0 | 27.67 ms | 0.526 ms | 0.516 ms |  1.00 |    0.00 | 940.0000 | 640.0000 | 400.0000 | 4673.37 KB |
|  Version1 | 27.65 ms | 0.211 ms | 0.197 ms |  1.00 |    0.01 | 900.0000 | 640.0000 | 380.0000 | 4673.68 KB |
|  Version2 | 26.48 ms | 0.302 ms | 0.268 ms |  0.96 |    0.02 | 940.0000 | 660.0000 | 400.0000 | 4656.98 KB |
|  Version3 | 28.08 ms | 0.546 ms | 0.783 ms |  1.01 |    0.04 | 940.0000 | 640.0000 | 400.0000 | 4657.76 KB |
|  Version4 | 28.16 ms | 0.541 ms | 0.480 ms |  1.02 |    0.02 | 900.0000 | 620.0000 | 360.0000 | 4657.89 KB |
|  Version5 | 28.61 ms | 0.369 ms | 0.345 ms |  1.03 |    0.02 | 940.0000 | 660.0000 | 400.0000 | 4657.74 KB |
|  Version6 | 28.10 ms | 0.554 ms | 0.638 ms |  1.02 |    0.02 | 720.0000 | 440.0000 | 220.0000 | 3757.36 KB |
|  Version7 | 27.70 ms | 0.526 ms | 0.540 ms |  1.00 |    0.02 | 540.0000 | 220.0000 |        - |  2852.3 KB |
|  Version8 | 25.45 ms | 0.482 ms | 0.474 ms |  0.92 |    0.03 | 540.0000 | 220.0000 |        - | 2883.25 KB |
|  Version9 | 23.19 ms | 0.461 ms | 0.600 ms |  0.84 |    0.03 |  40.0000 |  20.0000 |        - |  237.55 KB |
| Version10 | 21.52 ms | 0.430 ms | 0.460 ms |  0.78 |    0.02 | 480.0000 | 480.0000 | 480.0000 | 2029.17 KB |
```

#### 10 000 items

```
|    Method |     Mean |   Error |  StdDev | Ratio |     Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|---------- |---------:|--------:|--------:|------:|----------:|----------:|----------:|----------:|
|  Version0 | 204.4 ms | 0.76 ms | 0.63 ms |  1.00 | 5800.0000 | 1920.0000 |  980.0000 |  53.98 MB |
|  Version1 | 205.9 ms | 1.20 ms | 1.06 ms |  1.01 | 5800.0000 | 1980.0000 |  980.0000 |  53.98 MB |
|  Version2 | 206.6 ms | 0.51 ms | 0.48 ms |  1.01 | 5800.0000 | 2000.0000 |  980.0000 |  53.96 MB |
|  Version3 | 205.1 ms | 0.97 ms | 0.91 ms |  1.00 | 5800.0000 | 2000.0000 |  980.0000 |  53.96 MB |
|  Version4 | 205.7 ms | 1.25 ms | 1.17 ms |  1.01 | 5800.0000 | 2000.0000 |  980.0000 |  53.96 MB |
|  Version5 | 206.2 ms | 0.78 ms | 0.70 ms |  1.01 | 5800.0000 | 2000.0000 |  980.0000 |  53.96 MB |
|  Version6 | 200.4 ms | 1.17 ms | 1.04 ms |  0.98 | 5820.0000 | 2020.0000 | 1000.0000 |  36.36 MB |
|  Version7 | 191.8 ms | 0.91 ms | 0.81 ms |  0.94 | 5000.0000 | 1420.0000 |  680.0000 |  27.55 MB |
|  Version8 | 173.0 ms | 1.08 ms | 0.96 ms |  0.85 | 5040.0000 | 1300.0000 |  620.0000 |  27.85 MB |
|  Version9 | 137.5 ms | 0.89 ms | 0.74 ms |  0.67 |  400.0000 |  180.0000 |   60.0000 |   2.19 MB |
| Version10 | 140.8 ms | 0.62 ms | 0.51 ms |  0.69 | 1140.0000 | 1120.0000 |  980.0000 |  32.99 MB |
```

### HttpClientBenchmark

#### 10 items

```
|    Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------- |---------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|  Version0 | 4.548 ms | 0.0854 ms | 0.0799 ms |  1.00 |    0.00 |     - |     - |     - |  74.01 KB |
|  Version1 | 4.511 ms | 0.0842 ms | 0.0788 ms |  0.99 |    0.02 |     - |     - |     - |  74.25 KB |
|  Version2 | 4.342 ms | 0.0868 ms | 0.0811 ms |  0.95 |    0.02 |     - |     - |     - |  57.41 KB |
|  Version3 | 4.270 ms | 0.0797 ms | 0.0853 ms |  0.94 |    0.02 |     - |     - |     - |  58.54 KB |
|  Version4 | 4.300 ms | 0.0663 ms | 0.0554 ms |  0.94 |    0.02 |     - |     - |     - |  58.63 KB |
|  Version5 | 4.346 ms | 0.0493 ms | 0.0461 ms |  0.96 |    0.02 |     - |     - |     - |  58.63 KB |
|  Version6 | 4.314 ms | 0.0844 ms | 0.0938 ms |  0.95 |    0.03 |     - |     - |     - |  52.54 KB |
|  Version7 | 4.298 ms | 0.0843 ms | 0.0828 ms |  0.95 |    0.02 |     - |     - |     - |  43.59 KB |
|  Version8 | 4.271 ms | 0.0848 ms | 0.0793 ms |  0.94 |    0.03 |     - |     - |     - |  43.84 KB |
|  Version9 | 4.363 ms | 0.0812 ms | 0.0869 ms |  0.96 |    0.03 |     - |     - |     - |  26.84 KB |
| Version10 | 4.334 ms | 0.0644 ms | 0.0602 ms |  0.95 |    0.02 |     - |     - |     - |   5.57 KB |
```

#### 100 items

```
|    Method |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|---------- |----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|
|  Version0 | 10.379 ms | 0.1504 ms | 0.1256 ms |  1.00 |    0.00 | 80.0000 | 40.0000 | 40.0000 | 494.44 KB |
|  Version1 | 10.238 ms | 0.0864 ms | 0.0766 ms |  0.99 |    0.02 | 80.0000 | 40.0000 | 40.0000 | 494.67 KB |
|  Version2 |  9.185 ms | 0.1736 ms | 0.1539 ms |  0.88 |    0.02 | 80.0000 | 40.0000 | 40.0000 | 477.84 KB |
|  Version3 |  9.212 ms | 0.1756 ms | 0.1642 ms |  0.88 |    0.02 | 80.0000 | 40.0000 | 40.0000 | 478.96 KB |
|  Version4 |  9.221 ms | 0.1843 ms | 0.2122 ms |  0.89 |    0.03 | 80.0000 | 40.0000 | 40.0000 | 479.05 KB |
|  Version5 |  9.190 ms | 0.1383 ms | 0.1226 ms |  0.89 |    0.01 | 80.0000 | 40.0000 | 40.0000 | 479.05 KB |
|  Version6 |  9.070 ms | 0.1071 ms | 0.0949 ms |  0.87 |    0.01 | 60.0000 | 20.0000 | 20.0000 | 391.59 KB |
|  Version7 |  9.134 ms | 0.1362 ms | 0.1274 ms |  0.88 |    0.01 | 60.0000 |       - |       - | 301.31 KB |
|  Version8 |  8.923 ms | 0.1705 ms | 0.1824 ms |  0.85 |    0.02 | 60.0000 |       - |       - | 304.77 KB |
|  Version9 |  9.456 ms | 0.1787 ms | 0.1986 ms |  0.91 |    0.03 |       - |       - |       - |   41.8 KB |
| Version10 |  8.497 ms | 0.1672 ms | 0.1305 ms |  0.82 |    0.01 | 40.0000 | 40.0000 | 40.0000 | 139.03 KB |
```

#### 1000 items

```
|    Method |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|---------- |---------:|---------:|---------:|---------:|------:|--------:|---------:|---------:|---------:|-----------:|
|  Version0 | 27.98 ms | 0.299 ms | 0.265 ms | 28.07 ms |  1.00 |    0.00 | 880.0000 | 620.0000 | 360.0000 | 4626.33 KB |
|  Version1 | 27.83 ms | 0.394 ms | 0.369 ms | 27.71 ms |  1.00 |    0.02 | 900.0000 | 660.0000 | 380.0000 | 4626.47 KB |
|  Version2 | 26.58 ms | 0.217 ms | 0.181 ms | 26.54 ms |  0.95 |    0.01 | 960.0000 | 660.0000 | 420.0000 | 4609.57 KB |
|  Version3 | 26.71 ms | 0.468 ms | 0.438 ms | 26.53 ms |  0.96 |    0.02 | 960.0000 | 660.0000 | 420.0000 | 4610.61 KB |
|  Version4 | 26.85 ms | 0.296 ms | 0.262 ms | 26.83 ms |  0.96 |    0.01 | 940.0000 | 640.0000 | 400.0000 | 4610.89 KB |
|  Version5 | 29.20 ms | 0.579 ms | 1.431 ms | 29.22 ms |  0.99 |    0.08 | 980.0000 | 680.0000 | 440.0000 | 4611.32 KB |
|  Version6 | 28.76 ms | 0.572 ms | 0.744 ms | 28.71 ms |  1.03 |    0.03 | 740.0000 | 440.0000 | 220.0000 | 3710.51 KB |
|  Version7 | 28.69 ms | 0.559 ms | 0.886 ms | 28.84 ms |  1.03 |    0.03 | 520.0000 | 200.0000 |        - |  2805.2 KB |
|  Version8 | 25.28 ms | 0.358 ms | 0.317 ms | 25.30 ms |  0.90 |    0.01 | 560.0000 | 220.0000 |        - | 2836.12 KB |
|  Version9 | 21.34 ms | 0.426 ms | 1.188 ms | 20.90 ms |  0.83 |    0.03 |  40.0000 |  20.0000 |        - |  190.46 KB |
| Version10 | 19.99 ms | 0.258 ms | 0.242 ms | 19.99 ms |  0.71 |    0.01 | 460.0000 | 460.0000 | 460.0000 | 1982.46 KB |
```
#### 10 000 items

```
|    Method |     Mean |   Error |  StdDev | Ratio |     Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|---------- |---------:|--------:|--------:|------:|----------:|----------:|---------:|----------:|
|  Version0 | 201.7 ms | 1.21 ms | 1.01 ms |  1.00 | 5740.0000 | 2000.0000 | 980.0000 |  53.52 MB |
|  Version1 | 206.2 ms | 0.73 ms | 1.05 ms |  1.02 | 5740.0000 | 2000.0000 | 980.0000 |  53.52 MB |
|  Version2 | 204.8 ms | 0.97 ms | 0.91 ms |  1.02 | 5840.0000 | 2000.0000 | 980.0000 |  53.51 MB |
|  Version3 | 204.1 ms | 0.60 ms | 0.57 ms |  1.01 | 5800.0000 | 2000.0000 | 980.0000 |  53.51 MB |
|  Version4 | 206.2 ms | 1.16 ms | 1.09 ms |  1.02 | 5800.0000 | 2000.0000 | 980.0000 |  53.51 MB |
|  Version5 | 205.0 ms | 0.89 ms | 0.79 ms |  1.02 | 5800.0000 | 2000.0000 | 980.0000 |  53.51 MB |
|  Version6 | 198.7 ms | 1.38 ms | 1.29 ms |  0.98 | 5800.0000 | 2000.0000 | 980.0000 |   35.9 MB |
|  Version7 | 192.7 ms | 1.10 ms | 1.03 ms |  0.96 | 4960.0000 | 1420.0000 | 600.0000 |  27.09 MB |
|  Version8 | 171.9 ms | 0.90 ms | 0.80 ms |  0.85 | 5020.0000 | 1020.0000 | 480.0000 |  27.39 MB |
|  Version9 | 137.3 ms | 1.46 ms | 1.30 ms |  0.68 |  300.0000 |  120.0000 |  40.0000 |   1.73 MB |
| Version10 | 138.4 ms | 1.21 ms | 1.07 ms |  0.69 | 1060.0000 | 1040.0000 | 980.0000 |  32.53 MB |
```
