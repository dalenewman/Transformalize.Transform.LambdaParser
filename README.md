### Overview

This adds an eval transform to Transformalize using [NReco.LambdaParser](https://github.com/nreco/lambdaparser).

### Usage

```xml
<cfg name="Test">
    <entities>
        <add name="Test">
            <rows>
                <add text="SomethingWonderful" number="2" />
            </rows>
            <fields>
                <add name="text" />
                <add name="number" type="int" />
            </fields>
            <calculated-fields>
                <add name="evaluated" t='eval(text + " " + number)' />
            </calculated-fields>
        </add>
    </entities>
</cfg>
```

This produces `SomethingWonderful 2`

### Benchmark

``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2742192 Hz, Resolution=364.6718 ns, Timer=TSC
  [Host]       : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3221.0
  LegacyJitX64 : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit LegacyJIT/clrjit-v4.7.3221.0;compatjit-v4.7.3221.0

Job=LegacyJitX64  Jit=LegacyJit  Platform=X64  
Runtime=Clr  

```
|             Method |     Mean |    Error |   StdDev | Ratio | RatioSD |
|------------------- |---------:|---------:|---------:|------:|--------:|
|        &#39;5000 rows&#39; | 409.4 ms | 4.895 ms | 4.578 ms |  1.00 |    0.00 |
| &#39;5000 rows 1 eval&#39; | 440.9 ms | 6.203 ms | 5.803 ms |  1.08 |    0.02 |