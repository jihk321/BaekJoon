using System;
namespace BaekJoon
{
	public class DVD
	{
		public void Start()
		{
			string[] size = Input();
			string[] point = Input();
			string[] speed = Input();

			int[] dvdData = new int[6];
			int[] tvSize = new int[2];
			ArrayToIntParser(dvdData, size[..2].Concat(point).Concat(speed).ToArray());
			ArrayToIntParser(tvSize, size[2..4]);

			RectagleData dvd = new RectagleData(dvdData[0], dvdData[1], dvdData[2], dvdData[3], dvdData[4], dvdData[5]);
			RectagleData tv = new RectagleData(tvSize[0], tvSize[1], 0, 0, 0, 0);

			Console.WriteLine($"TV : Width {tv.Width} Height {tv.Height} DVD : Widht {dvd.Width} Height {dvd.Height}");

			int seconds = 0;

			do
			{
				Console.WriteLine($"X : {dvd.X} Y : {dvd.Y} HorizonSpeed {dvd.HorizontalSpeed} VerticalSpeed {dvd.VerticalSpeed} Count : {seconds}");
				Move(tv, dvd);
				//IsContact(tv, dvd);
				seconds++;
			} while (!IsVertex(tv, dvd));

			Console.WriteLine($"도착 {seconds}");
		}
		public void Move(RectagleData origin, RectagleData target)
		{
			if(target.X + target.HorizontalSpeed >= 0 && target.X + target.Width <= origin.Width)
				target.X += target.HorizontalSpeed;
			if(target.Y + target.VerticalSpeed >= 0 && target.Y + target.Height <= origin.Height)
				target.Y += target.VerticalSpeed;
			
            if (target.X == 0 || target.X == origin.Width)
                target.VerticalSpeed *= -1;
            if (target.Y == 0 || target.Y == origin.Height)
                target.HorizontalSpeed *= -1;
        }
		public string[] Input()
		{
			Console.WriteLine();
			string? input = Console.ReadLine();

			if (input == null)
			{
				return Array.Empty<string>();
			}

			return input.Split(' ');
		}

		public void ArrayToIntParser(int[] intArray, string[] stringArray)
		{
			int index = 0;

			foreach (string @string in stringArray)
			{
				intArray[index] = int.Parse(@string);
				index++;
			}
		}

		public void IsContact(RectagleData origin, RectagleData target)
		{
			if (target.X == 0 || target.X == origin.Width && target.CanHorizontalSpeedChange)
				target.VerticalSpeed *= -1;
			else if (target.Y == 0 || target.Y == origin.Height && target.CanVerticalSpeedChange)
				target.HorizontalSpeed *= -1;
		}

		public static bool IsVertex(RectagleData origin, RectagleData target)
		{
			if (target.X == 0 && target.Y == 0) return true;
			else if (target.X == 0 && target.Y + target.Height == origin.Height) return true;
			else if (target.X + target.Width == origin.Width && target.Y == 0) return true;
			else if (target.X + target.Width == origin.Width && target.Y + target.Height == origin.Height) return true;
			else return false;
		}
	}

	public class RectagleData
	{
		public int Width, Height;
		public int X,Y;
		public int HorizontalSpeed, VerticalSpeed;
		public bool CanHorizontalSpeedChange, CanVerticalSpeedChange;

		public RectagleData(int width, int height, int x, int y, int horizontalSpeed, int verticalSpeed)
		{
			Width = width;
			Height = height;
			X = x;
			Y = y;
			HorizontalSpeed = horizontalSpeed;
			VerticalSpeed = verticalSpeed;
			CanHorizontalSpeedChange = CanVerticalSpeedChange = true;
		}

		public void Move()
		{
			if(X + HorizontalSpeed >= 0)
			{
				this.X += HorizontalSpeed;
				CanHorizontalSpeedChange = true;
			}
			else
			{
				CanHorizontalSpeedChange = false;
			}

			if(Y + VerticalSpeed >= 0)
			{
				this.Y += VerticalSpeed;
				CanVerticalSpeedChange = true;
			}
			else
			{
				CanVerticalSpeedChange = false;
			}
        }
	}
}

