using System;
using System.IO;
using System.Reflection;
using System.Threading;
using PongCore;
using PongRender;

namespace SampleApp104466305
{
    class Program
    {
        static void Main(string[] args)
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string settingsPath = Path.Combine(exeDir, "pong.settings.json");

            // PongCore.dll + Newtonsoft.Json.dll
            SimulationSettings settings = SettingsLoader.Load(settingsPath);

            if (args.Length > 0 && int.TryParse(args[0], out int overrideDelay))
            {
                settings.DelayMilliseconds = overrideDelay;
            }

            Console.CursorVisible = false;
            Console.WriteLine("Pong? Simulator");
            Console.WriteLine("104466305 | SWE40006");
            Console.WriteLine("Press any key to stop.");
            Console.WriteLine();

            int laneRow = Console.CursorTop;
            Console.WriteLine();
            Console.WriteLine();
            int statusRow = laneRow + 2;

            // PongCore.dll
            var simulation = new BallSimulation(Console.WindowWidth - 1);

            // PongRender.dll
            var renderer = new LaneRenderer(settings.BallChar, settings.WallChar);

            while (!Console.KeyAvailable)
            {
                int width = Console.WindowWidth - 1;

                if (width < 5)
                {
                    Thread.Sleep(settings.DelayMilliseconds);
                    continue;
                }

                simulation.Resize(width);

                Console.SetCursorPosition(0, laneRow);
                Console.Write(renderer.RenderLane(simulation.LaneWidth, simulation.Position));

                Console.SetCursorPosition(0, statusRow);
                Console.Write(renderer.RenderStatus(
                    simulation.Bounces, simulation.Position, simulation.LaneWidth));

                simulation.Step();
                Thread.Sleep(settings.DelayMilliseconds);
            }

            Console.ReadKey(true);
            Console.SetCursorPosition(0, statusRow + 2);
            Console.CursorVisible = true;
            Console.WriteLine("Stopped after " + simulation.Bounces + " bounces.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}