using System.Text;

namespace PongRender
{
    public class LaneRenderer
    {
        private readonly char _ball;
        private readonly char _wall;

        public LaneRenderer(char ball, char wall)
        {
            _ball = ball;
            _wall = wall;
        }

        public string RenderLane(int width, int ballPosition)
        {
            if (width < 3) return string.Empty;

            char[] lane = new char[width];

            for (int i = 0; i < width; i++) lane[i] = ' ';

            lane[0] = _wall;
            lane[width - 1] = _wall;

            if (ballPosition > 0 && ballPosition < width - 1)
            {
                lane[ballPosition] = _ball;
            }

            return new string(lane);
        }

        public string RenderStatus(int bounces, int position, int width)
        {
            var sb = new StringBuilder();
            sb.Append("Bounces: ").Append(bounces.ToString().PadRight(6));
            sb.Append("Position: ").Append(position.ToString().PadRight(4));
            sb.Append("Width: ").Append(width.ToString().PadRight(4));
            return sb.ToString();
        }
    }
}