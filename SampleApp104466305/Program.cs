using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp104466305
{
    class Program
    {
        static void Main(string[] args)
        {
            int delay = args.Length > 0 && int.TryParse(args[0], out int d) ? d : 40;

            Console.CursorVisible = false;
            Console.WriteLine("Pong? Simulator");
            Console.WriteLine("104466305 | SWE40006");
            Console.WriteLine("Press any key to stop.");
            Console.WriteLine();

            int laneRow = Console.CursorTop;
            Console.WriteLine();
            Console.WriteLine();
            int statusRow = laneRow + 2;

            int position = 1;
            int direction = 1;
            int bounces = 0;

            while (!Console.KeyAvailable)
            {
                int width = Console.WindowWidth - 1;
                if (width < 5) { Thread.Sleep(delay); continue; }

                if (position >= width - 2) position = width - 2;
                if (position < 1) position = 1;

                Console.SetCursorPosition(0, laneRow);
                Console.Write(RenderLane(width, position));

                Console.SetCursorPosition(0, statusRow);
                Console.Write($"Bounces: {bounces,-6} Position: {position,-4} Width: {width,-4}");

                position += direction;

                if (position >= width - 2 || position <= 1)
                {
                    direction = -direction;
                    bounces++;
                }

                Thread.Sleep(delay);
            }

            Console.ReadKey(true);
            Console.SetCursorPosition(0, statusRow + 2);
            Console.CursorVisible = true;
            Console.WriteLine($"Stopped after {bounces} bounces.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static string RenderLane(int width, int ballPosition)
        {
            char[] lane = new char[width];

            for (int i = 0; i < width; i++) lane[i] = ' ';

            lane[0] = '|';
            lane[width - 1] = '|';
            lane[ballPosition] = 'O';

            return new string(lane);
        }
    }
}