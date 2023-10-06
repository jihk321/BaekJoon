using System;
namespace BaekJoon
{
	public class _2754
	{
		char[] grade = { 'A', 'B', 'C', 'D', 'F' };

		public void Main()
		{
			string input = Console.ReadLine();

			float score = GetScore(input);

			if (!float.IsNaN(score))
				Console.WriteLine(score.ToString("F1"));
		}

		public float GetScore(string input)
		{
			int index = Array.IndexOf(grade, input[0]);

			if (index == -1) return float.NaN;

			var score = MathF.Abs(index - 4);

			if (input.Count() < 2) return score;

			switch(input[1])
			{
				case '+': score += 0.3f; break;
				case '-': score -= 0.3f; break;
			}

			return score;
		}
	}
}