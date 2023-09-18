using System;

namespace BaekJoon
{
	public class LuckyDVD
	{
		public void Main()
		{
			string[] size = Input();
			string[] point = Input();
			string[] speed = Input();

			int[] dvdSize = new int[2];
			int[] tvSize = new int[2];
			int[] dvdPosition = new int[2];
			int[] dvdSpeed = new int[2];

			ArrayToIntParser(dvdSize, size[..2]);
			ArrayToIntParser(tvSize, size[2..4]);
			ArrayToIntParser(dvdPosition, point);
			ArrayToIntParser(dvdSpeed, speed);

			Console.WriteLine($"TV : Width {tvSize[0]} Height {tvSize[1]} DVD : Widht {dvdSize[0]} Height {dvdSize[1]}");
			Tuple<int, int>  vertex = new Tuple<int, int>(tvSize[0], tvSize[1]);

			int seconds = 0;

			do
			{
				dvdPosition = Move(dvdPosition, dvdSpeed);
				dvdSpeed = ContactLine(vertex, dvdPosition, dvdSpeed);
				seconds++;
				Console.WriteLine(seconds);
			}
			while (!IsVertex(tvSize, dvdSize));
			Console.WriteLine($"꼭짓점 도착 {seconds}");
		}

		public static string[] Input()
		{
			Console.WriteLine();
			string? input = Console.ReadLine();

			if (input == null)
			{
				return Array.Empty<string>();
			}

			return input.Split(' ');
		}

		public static void ArrayToIntParser(int[] intArray, string[] stringArray)
		{
			int index = 0;

			foreach (string @string in stringArray)
			{
				intArray[index] = int.Parse(@string);
				index++;
			}
		}

		public static bool IsVertex(int[] rect, int[] target)
		{
			int sum = target.Sum();
			if (sum == 0 || sum == rect.Sum()) return true;
			else if (target[0] == 0 || target[1] == 0)
			{
				if (sum == target[0] || sum == target[1]) return true;
			}

			return false;
		}

		public static int[] Move(int[] target, int[] speed)
		{
			if (target[0] != 0)
				target[0] += speed[0];
			if (target[1] != 0)
				target[1] += speed[1];

			return target;
		}

		public static int[] ContactLine(Tuple<int,int> vertex, int[] target, int[] speed)
		{
			if (target[0] == 0 || target[0] == vertex.Item1)
			{
				speed[1] = -speed[1];
			}
			else if (target[1] == 0 || target[1] == vertex.Item2)
				speed[0] = -speed[0];
			return speed;
		}
	}

	public class Rectangle
	{
		int width, height, pointX, pointY;

		Dictionary<string, Speed> rectSpeed = new Dictionary<string, Speed>();

		public void SetSpeed(string side, int value)
		{
			rectSpeed.Add(side, new Speed());
			//rectSpeed[side].speed = value;
		}

		public void Reverse(string side)
		{
			if(rectSpeed.TryGetValue(side, out var speed))
			{
				if (!speed.canMove) return;

				speed.speed *= -1;
			}
		}

		public Rectangle(int w, int h, int x, int y)
		{
			this.width = w;
			this.height = h;
			this.pointX = x;
			this.pointY = y;
		}
	}

	public struct Speed
	{
		public int speed;
		public bool canMove;
	}
}

