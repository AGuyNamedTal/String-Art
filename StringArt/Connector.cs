using System.Drawing;

namespace StringArt
{
    public class Connector
    {
        private PointF _point1 = new PointF(-1, -1);
        private PointF _point2 = new PointF(-1, -1);

        public Connector()
        {

        }

        public Connector(PointF point1, PointF point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        private void SwapPoints()
        {
            PointF temp = _point1;
            _point1 = _point2;
            _point2 = temp;
        }

        public PointF Point1
        {
            get => _point1;
            set
            {
                _point1 = value;
                if (_point1.X > _point2.X)
                {
                    SwapPoints();
                }
                else if (_point1.X == _point2.X)
                {
                    if (_point1.Y > _point2.Y)
                    {
                        SwapPoints();
                    }
                }
            }
        }
        public PointF Point2
        {
            get => _point2;
            set
            {
                _point2 = value;
                if (_point2.X < _point1.X)
                {
                    SwapPoints();
                }
                else if (_point2.X == _point1.X)
                {
                    if (_point2.Y < _point1.Y)
                    {
                        SwapPoints();
                    }
                }
            }
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Connector connector))
            {
                return false;
            }

            return connector._point1.Equals(_point1) && connector._point2.Equals(_point2);
        }

        protected bool Equals(Connector other)
        {
            return _point1.Equals(other._point1) && _point2.Equals(other._point2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_point1.GetHashCode() * 397) ^ _point2.GetHashCode();
            }
        }
    }
}
