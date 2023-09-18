using System;
namespace BaekJoon
{
    public class PrintStar
    {
        static int num;
        public static void Input()
        {
            int.TryParse(Console.ReadLine(), out num);
        }

        public static void Main()
        {
            Input();

            int standard = 2 * num - 1;
            int star = 1;

            for (int i = 0; i < num; i++)
            {
                for (int j = 1; j <= standard; j++)
                {
                    if (j <= num - star || j >= num + star)
                        Console.Write(" ");
                    else
                        Console.Write("*");
                }

                if (i != num) star++;
                Console.Write("\n");
            }

            for (int k = 1; k < num; k++)
            {
                star--;

                for (int j = 1; j <= standard; j++)
                {
                    if (j <= num - star || j >= num + star)
                        Console.Write(" ");
                    else
                        Console.Write("*");

                }
                Console.Write("\n");
            }
        }
    }
}

