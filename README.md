# TimeIt

This is a trivial piece of code I use to play around with performance improvements and explore how different methods perform. It is just above the "throw away code" criteria.

`TimeIt` provides a simple way to calculate how many times an
`Action` can be executed with a number of seconds.

Note: This is not a complete benchmarking solution. For that, checkout [Benchmark.Net].

The `Action` being tested will be executed at least twice. Ideally it will not have side effects.

```csharp

void SomeActionToTest() {
    System.Threading.Thread.Sleep(10);
}

var result = TimeIt.Time(3, nameof(SomeActionToTest), SomeActionToTest);

Console.WriteLine(result);
// TimedResult { MethodName = SomeActionToTest, ExecutionCount = xxx }

```

The results of this should only be trusted superficially. It provides a simple comparison of execution time of a piece of code. It doesn't handle side effects or any other performance metric well.

I tend to always have some comparison or other expection inside the method that I test. I have experienced extremely high execution counts because the compiler optimized away the execution call.

Take a look at the sample files for some ideas of what to test.

[Benchmark.Net]: https://benchmarkdotnet.org/
