namespace MinerServer.CoreItems
{
    public class Position
    {
        private StateSaver<double> xPosition;
        private StateSaver<double> yPosition;

        public Position()
            : this(0, 0)
        {
        }

        public Position(double x, double y)
        {
            xPosition = new StateSaver<double>(x);
            yPosition = new StateSaver<double>(y);
        }

        public double X
        {
            get { return xPosition.Value; }
        }

        public double Y
        {
            get { return yPosition.Value; }
        }

        public bool HasChanges
        {
            get { return xPosition.HasChanges || yPosition.HasChanges; }
        }

        public void SetPosition(double x, double y)
        {
            xPosition.Value = x;
            yPosition.Value = y;
        }
    }
}