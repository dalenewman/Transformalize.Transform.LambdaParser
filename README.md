### Overview

This adds an eval transform to Transformalize using [NReco.LambdaParser](https://github.com/nreco/lambdaparser).  It is a plug-in compatible with Transformalize 0.3.3-beta.

Build the Autofac project and put it's output into Transformalize's *plugins* folder.

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

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.125)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2742192 Hz, Resolution=364.6718 ns, Timer=TSC
  [Host]       : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0
  LegacyJitX64 : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit LegacyJIT/clrjit-v4.7.2600.0;compatjit-v4.7.2600.0
  LegacyJitX86 : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0

Jit=LegacyJit  Runtime=Clr  

```
|                  Method |          Job | Platform |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------------------ |------------- |--------- |---------:|----------:|----------:|-------:|---------:|
|         &#39;500 test rows&#39; | LegacyJitX64 |      X64 | 64.14 ms | 0.2465 ms | 0.2185 ms |   1.00 |     0.00 |
| &#39;500 rows with 3 evals&#39; | LegacyJitX64 |      X64 | 81.94 ms | 0.8216 ms | 0.7283 ms |   1.28 |     0.01 |
|                         |              |          |          |           |           |        |          |
|         &#39;500 test rows&#39; | LegacyJitX86 |      X86 | 69.00 ms | 0.6474 ms | 0.5739 ms |   1.00 |     0.00 |
| &#39;500 rows with 3 evals&#39; | LegacyJitX86 |      X86 | 76.58 ms | 1.2445 ms | 1.1032 ms |   1.11 |     0.02 |
