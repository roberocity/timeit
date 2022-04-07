#load "../TimeIt.cs"

int seed = 3297;

if (Args.Count == 1 && int.TryParse(Args[0], out var s)) {
    seed = s;
}
var rand = new Random(s);

var min = 5;
var max = 50;

void RandomDelay() {
    System.Threading.Thread.Sleep(rand.Next(min, max));
}

var r = TimeIt.Time(3, nameof(RandomDelay), RandomDelay);

Console.WriteLine(r);