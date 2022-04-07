#load "../TimeIt.cs"

int a = 2;
int b = 4;

void SomeActionToTest() {
    if(6 != a + b) {
        //System.Threading.Thread.Sleep(5);
    }
}

var result = TimeIt.Time(3, nameof(SomeActionToTest), SomeActionToTest);

Console.WriteLine(result);
// TimedResult { MethodName = SomeActionToTest, ExecutionCount = 500 }
