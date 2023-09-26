namespace BaekJoon;

public class YourGrade
{
	 string[] grades = { "A+", "A0", "B+", "B0", "C+", "C0", "D+", "D0", "F" };

	 float sum, totalSum;

	public  void Main()
	{
		string[] input = new string[20];
		int i = 0;
		do
		{
			input[i] = Console.ReadLine();
			i++;
		}
		while (i < 20);

		Console.WriteLine(GetAverage(input));
	}

	public  float GetAverage(string[] txt)
	{
		foreach (string line in txt)
		{
			string[] word = line.Split(' ');
			if(grades.Contains(word.Last()))
			{
				float subjectGrade = GetScore(word.Last());
				float score = float.Parse(word[1]);
				totalSum += subjectGrade * score;
				sum += score;
			}
		}

		return totalSum/ sum;

	}

	public  float GetScore(string grade)
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
