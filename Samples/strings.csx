#load "../TimeIt.cs"

var stringCount = 1000;

if (Args.Count == 1 && int.TryParse(Args[0], out var c))
{
    stringCount = c;
}

var rand = new Random(375234);

var source = Enumerable.Range(1, stringCount)
    .Select(n => new string (
                 Enumerable.Range(1, rand.Next(101))
                .Select(c => (char) rand.Next(127))
                .ToArray())).ToArray();

var lengths = source.Select(s => s.Length).ToArray();
var sum = lengths.Sum();
var avg = lengths.Average();
var min = lengths.Min();
var max = lengths.Max();


Console.WriteLine($"source length stats: count: {lengths.Length}, sum: {sum}, avg: {avg}, min: {min}, max: {max}");
Console.WriteLine();

void TestConcat() {
    "a".Equals(string.Concat(source));
}

void TestJoin() {
    "a".Equals(string.Join("", source));
}

void TestStringBuilder() {
    var sb = new System.Text.StringBuilder();
    foreach(var s in source) {
        sb.Append(s);
    }
    "a".Equals(sb);
}

var results = new List<TimedResult>();

results.Add(TimeIt.Time(3, "concat", TestConcat));
results.Add(TimeIt.Time(3, "join", TestConcat));
results.Add(TimeIt.Time(3, "string builder", TestConcat));

foreach (var r in results)
{
    Console.WriteLine(r);
}
