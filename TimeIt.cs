using System;
using System.Diagnostics;

public record TimedResult {
    public TimedResult(string methodName, int executionCount) {
        MethodName = methodName;
        ExecutionCount = executionCount;
    }
    public string MethodName { get; }
    public int ExecutionCount { get; }
}

public class TimeIt
{
    public static TimedResult Time(
        int seconds,
        string methodName,
        Action fn
        )
    {
        // run once to "prime the pump" before starting the timer
        fn.Invoke();

        var executionCount = 0;
        var timer = Stopwatch.StartNew();

        while (timer.Elapsed.TotalSeconds < seconds)
        {
            fn.Invoke();

            if (timer.Elapsed.TotalSeconds < seconds)
            {
                executionCount++;
            }
        }

        timer.Stop();

        return new TimedResult(methodName, executionCount);
    }
}
