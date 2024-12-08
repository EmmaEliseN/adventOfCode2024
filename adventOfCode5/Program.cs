class Program
{
    static void Main()
    {
        string relativePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "input.txt");
        string relativePath2 = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "input2.txt");
        string path = Path.GetFullPath(relativePath);
        string path2 = Path.GetFullPath(relativePath2);


        string[] inputRules = File.ReadAllLines(path);
        string[] inputUpdates = File.ReadAllLines(path2);

        int updateOk = 0;
        int updateNowOk = 0;

        List<string> needsReordering = [];

        foreach (string update in inputUpdates)
        {
            string[] updateParts = update.Split(",");
            if (!CheckInput(updateParts, inputRules))
            {
                needsReordering.Add(update);
            }
            else
            {
                updateOk += int.Parse(updateParts[updateParts.Length / 2]);
            }
        }

        foreach (string update in needsReordering)
        {
            string[] updateParts = update.Split(",");
            while (!CheckInput(updateParts, inputRules))
            {
                updateParts = ReOrderUpdate(updateParts, inputRules);
            }
            updateNowOk += int.Parse(updateParts[updateParts.Length / 2]);

        }

        Console.WriteLine("Part1 " + updateOk);
        Console.WriteLine("Part2 " + updateNowOk);

    }

    static string[] ReOrderUpdate(string[] update, string[] rules)
    {
        for (int i = 0; i < update.Length; i++)
        {
            var appliedRules = rules.Where(r => r.Contains(update[i]));
            foreach (var ar in appliedRules)
            {
                string[] ruleParts = ar.Split("|");
                if (ruleParts[1] == update[i])
                {
                    if (update.Skip(i + 1).Any(x => x == ruleParts[0]))
                    {
                        var index = Array.IndexOf(update, ruleParts[0]);
                        var temp = update[i];
                        update[i] = update[index];
                        update[index] = temp;
                        return update;
                    };
                }
            }
        }
        return update;
    }

    static bool CheckInput(string[] update, string[] rules)
    {
        for (int i = 0; i < update.Length; i++)
        {
            var appliedRules = rules.Where(r => r.Contains(update[i]));
            foreach (var ar in appliedRules)
            {
                string[] ruleParts = ar.Split("|");
                if (ruleParts[1] == update[i])
                {
                    if (update.Skip(i + 1).Any(x => x == ruleParts[0]))
                    {
                        return false;
                    };
                }
            }
        }
        return true;
    }
}