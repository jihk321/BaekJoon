using System;
using System.Collections.Generic;
using System.Linq;

namespace BaekJoon;

public class YourGrade
{
    string[] grades = { "A+", "A0", "B+", "B0", "C+", "C0", "D+", "D0", "F" };
    float sum;
    public void Start()
    {
        string[] input = new string[20];
        int i = 0;
        do
        {
            input[i] = Console.ReadLine();
            i++;
        }
        while (i < 20);

        List<string> grade = SplitText(input);
        Calculate(grade);

    }

    public void Calculate(List<string> grades)
    {
        int subject = grades.Count;

        foreach (string grade in grades)

        {
            sum += GetScore(grade);
        }

        Console.WriteLine(sum / subject);
    }
    public List<string> SplitText(string[] txt)
    {
        List<string> grade = new List<string>();

        foreach (string line in txt)
        {
            if (grades.Contains(line.Split(' ').Last()))
                grade.Add(line.Split(' ').Last());
        }
        return grade;
    }

    public float GetScore(string grade)
    {
        var score = 0f;
        switch (grade)
        {
            case "A+": score = 4.5f; break;
            case "A0": score = 4.0f; break;
            case "B+": score = 3.5f; break;
            case "B0": score = 3.0f; break;
            case "C+": score = 2.5f; break;
            case "C0": score = 2.0f; break;
            case "D+": score = 1.5f; break;
            case "D0": score = 1.0f; break;
            case "F": score = 0f; break;
        }
        return score;
    }
}
