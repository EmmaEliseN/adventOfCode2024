using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        string path = "input.txt";
        string[] inputLines = File.ReadAllLines(path);

        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();

        foreach (string line in inputLines)
        {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                list1.Add(int.Parse(parts[0]));
                list2.Add(int.Parse(parts[1]));
            }
        }

        var sumDiff = GetSumDiff(list1, list2);
        var simularityScore = GetSimularityScore(list1, list2);


        Console.WriteLine(sumDiff);
        Console.WriteLine(simularityScore);

    }

    public static int GetSimularityScore(List<int> list1, List<int> list2)
    {
        var orderedList1 = list1.OrderBy(x => x).ToList();
        list1.OrderBy(x => x);
        var orderedList2 = list2.OrderBy(x => x).ToList();
        list2.OrderBy(x => x);
        var sumScore = 0;

        for (int i = 0; i < orderedList1.Count; i++)
        {
            var simularityFactor = orderedList2.FindAll(x => x == orderedList1[i]).Count;
            var score = simularityFactor * orderedList1[i];
            sumScore += score;

        }

        return sumScore;
    }

    public static int GetSumDiff(List<int> list1, List<int> list2)
    {
        var orderedList1 = list1.OrderBy(x => x).ToList();
        list1.OrderBy(x => x);
        var orderedList2 = list2.OrderBy(x => x).ToList();
        list2.OrderBy(x => x);
        var sumDiff = 0;

        for (int i = 0; i < orderedList1.Count; i++)
        {
            var diff = Math.Abs(orderedList1[i] - orderedList2[i]);
            sumDiff += diff;

        }

        return sumDiff;
    }


}
