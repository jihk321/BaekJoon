using System.Numerics;
using System;
using System.Linq;

namespace BaekJoon
{
	public class Snake
	{
		int size, rotation, plate, rotateNum =0;
		//Dictionary<int, char> rotationValue = new Dictionary<int, char>();
		List<char[]> rotationValue = new List<char[]>();
		public void main()
		{

			size = int.Parse(Console.ReadLine());
			rotation = int.Parse(Console.ReadLine());

			for (int i = 0; i < rotation; i++)
			{
				char[] input = Console.ReadLine().ToCharArray();
				
				rotationValue.Add(input);
			}

			// 처음엔 배열로 하려고 했는데 최대 최소가 정해져 있어 굳이 그럴 필요가 없었. int[,] plate = new int[2*size +1,2 *size +1];
			plate = 2 * size + 1;
			// 격자판의 사이즈
			Bam bam = new Bam(size);

			while(!IsDead(bam, plate))
			{
				Rotate(bam);
				bam.Move();
				rotateNum++;

			}

			Console.WriteLine(bam.moveCount);
		}

		public bool IsDead(Bam bam, int plates)
		{
			if (bam.x < 0 || bam.y < 0) return true;
			else if (bam.x > plates || bam.y > plates) return true;
			else return false;
		}

		public void Rotate(Bam bam)
		{
			if (rotationValue == null) return;

			int rotateTime = (int)Char.GetNumericValue( rotationValue[0][0]);

			if (rotateTime.Equals(rotateNum))
			{
				if (rotationValue[0][2] =='L')
					bam.angle -= 90;
				else bam.angle += 90;

				rotateNum = 1;
				rotationValue.RemoveAt(0);
			}

			switch(bam.angle)
			{
				case 360: bam.angle = 0; break;
				case -90: bam.angle = 270; break;
			}
		}



	}
		public struct Bam
		{
			public int x, y, angle, moveCount;

		List<Tuple<int, int>> body;

		public Bam(int zeroPoint)
		{
			angle = 90;
			body = new List<Tuple<int, int>>() { new Tuple<int, int>(zeroPoint,zeroPoint)};
			x = y = zeroPoint;
			moveCount = 0;
		}

		public void Move()
		{
			switch(angle)
			{
				case 0: y += 1; break;
				case 90: x += 1; break;
				case 180: y -= 1; break;
				case 270: x -= 1; break;
			}
			body.Add(new Tuple<int, int>(x, y));
			moveCount++;

			Console.WriteLine($"Current : {x} {y}");
		}
	}
}

