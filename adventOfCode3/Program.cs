
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string path = "input.txt";
        string input = File.ReadAllText(path);

        var matches = GetMatches(input);
        int sum2 = GetRes2(input);

        int sumOfMul = MultiplyMatches(matches);

        Console.WriteLine("1 " + sumOfMul);
        Console.WriteLine("2 " + sum2);
    }

    //mul\(\d{1,3},\d{1,3}\)
    static MatchCollection GetMatches(string input)
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);
        return matches;
    }

    static int MultiplyMatches(MatchCollection matches)
    {
        int sum = 0;
        foreach (Match match in matches)
        {
            string[] numbers = match.Value.Substring(4, match.Value.Length - 5).Split(',');
            int num1 = int.Parse(numbers[0]);
            int num2 = int.Parse(numbers[1]);
            sum += num1 * num2;
        }

        return sum;
    }

    static int GetRes2(string input)
    {
        int sum = 0;
        bool checkLast = false;

        while (input.Contains("don't()"))
        {
            var subToCheck = input.Split("don't()")[0];

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Sub " + subToCheck);
            var matches = GetMatches(subToCheck);
            sum = sum + MultiplyMatches(matches);
            input = input = input.Replace(subToCheck, string.Empty);
            checkLast = false;
            if (input.Contains("do()"))
            {
                string toRemove = input.Split("do()")[0];
                input = input.Replace(toRemove, string.Empty);
                checkLast = true;
            }
            else
            {
                break;
            }

        }

        if (checkLast)
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("Sista " + input);
            var matches = GetMatches(input);
            sum += MultiplyMatches(matches);
        }

        Console.WriteLine("----------------");

        return sum;

    }


}




