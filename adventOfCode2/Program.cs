
class Program
{
    static void Main()
    {
        string path = "input.txt";
        string[] inputLines = File.ReadAllLines(path);
        int safe = 0;
        int safe2 = 0;

        foreach (string line in inputLines)
        {
            List<int> levels = line.Split([' ']).Select(int.Parse).ToList();


            if (IsReportSafe(levels))
            {
                safe++;
                safe2++;
            }
            else if (TryMakeSafe(levels))
            {
                safe2++;
            }

        }

        Console.WriteLine("Part1: " + safe);
        Console.WriteLine("Part2: " + safe2);
    }

    static bool IsReportSafe(List<int> list)
    {
        int length = list.Count;

        if (!IsDiffOk(list))
        {
            return false;
        }

        if (list.SequenceEqual(list.OrderBy(x => x)))
        {
            return true;
        }

        if (list.SequenceEqual(list.OrderByDescending(x => x)))
        {
            return true;
        }

        return false;
    }

    static bool IsDiffOk(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            if (Math.Abs(list[i] - list[i - 1]) > 3 || Math.Abs(list[i] - list[i - 1]) == 0)
            {
                return false;
            }
        }
        return true;
    }

    static bool TryMakeSafe(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var tempList = new List<int>(list);
            tempList.RemoveAt(i);

            Console.WriteLine();
            if (IsReportSafe(tempList))
            {
                return true;
            }
        }
        return false;
    }
}




