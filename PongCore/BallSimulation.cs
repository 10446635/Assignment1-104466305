namespace PongCore
{
    public class BallSimulation
    {
        public int Position { get; private set; }
        public int Direction { get; private set; }
        public int Bounces { get; private set; }
        public int LaneWidth { get; private set; }

        public BallSimulation(int laneWidth)
        {
            LaneWidth = laneWidth;
            Position = 1;
            Direction = 1;
            Bounces = 0;
        }

        public void Resize(int laneWidth)
        {
            LaneWidth = laneWidth;

            int max = LaneWidth - 2;
            if (Position > max) Position = max;
            if (Position < 1) Position = 1;
        }

        public void Step()
        {
            Position += Direction;

            if (Position >= LaneWidth - 2 || Position <= 1)
            {
                Direction = -Direction;
                Bounces++;
            }
        }
    }
}