using System;
using System.IO;
using Newtonsoft.Json;

namespace PongCore
{
    public class SimulationSettings
    {
        public int DelayMilliseconds { get; set; }
        public string Ball { get; set; }
        public string Wall { get; set; }

        public SimulationSettings()
        {
            DelayMilliseconds = 40;
            Ball = "O";
            Wall = "|";
        }

        public char BallChar
        {
            get { return string.IsNullOrEmpty(Ball) ? 'O' : Ball[0]; }
        }

        public char WallChar
        {
            get { return string.IsNullOrEmpty(Wall) ? '|' : Wall[0]; }
        }
    }

    public static class SettingsLoader
    {
        public static SimulationSettings Load(string path)
        {
            try
            {
                if (!File.Exists(path)) return new SimulationSettings();

                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<SimulationSettings>(json)
                       ?? new SimulationSettings();
            }
            catch (Exception)
            {
                return new SimulationSettings();
            }
        }
    }
}