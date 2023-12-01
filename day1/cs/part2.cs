using System.Text.RegularExpressions;

namespace day1;

public class Part2
{
    [SetUp]
    public void Setup()
    {
    }

    static readonly Dictionary<string, string> replacements = new() {
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"}
    };

    public int Solve(string input)
    {
        var lines = input.Replace("\r", "").Split('\n');
        var count = lines.Length;
        var rex = new Regex(@"[^\d]");

        for(var i = 0; i<lines.Length; i++) {
            var line = lines[i];
            Console.Write(line + " --> ");

            var first = 0;
            for(var x = 0; x<line.Length; x++) {
                if (Char.IsNumber(line[x])) {
                    first = line[x].GetNumericValue();
                    break;
                }
                foreach(var key in replacements.Keys) {
                    if (x + key.Length <= line.Length) {
                        
                    }
                }
            }
            
            Console.Write(line + " --> ");

            line = rex.Replace(line, "");

            Console.Write(line + " --> ");

            line = line.First().ToString() + line.Last().ToString();
            lines[i] = line;

            Console.WriteLine(line);
        }


        Console.WriteLine();
        Console.WriteLine("----------");
        Console.WriteLine();

        var answer = lines.Select(x => Convert.ToInt32(x)).Sum();
        Console.WriteLine(answer);
        
        Console.WriteLine($"From {count} lines parsed to {lines.Count()} pairs");

        return answer;
    }

    [Test]
    [TestCase(@"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen", 281)]
    public void Solves_Including_Named_Digits(string input, int expected)
    {
        var answer = Solve(input);

        Assert.AreEqual(expected, answer);
    }

    [Test]
    public void Solve_Input() {
        var input = System.IO.File.ReadAllText("./../../../input.txt");
        var answer = Solve(input);
        // 50_911 < too low
        // 53_287 < too low
        // 53_551 < too high
        Assert.AreEqual(53_551, answer);
    }
}