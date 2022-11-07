

namespace GeometryLibrary
{
    public class Triangle : ISquare
    {
        public const double eps = Constants.CalculationAccuracy;
        private readonly Lazy<bool> _isRightTriangle;

        /// <exception cref="ArgumentException"></exception>
        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            CheckValidTriangle(edgeA, edgeB, edgeC);

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }

        public  double EdgeA { get; set; }
        public double EdgeB { get; set; }
        public double EdgeC { get; set; }
        public bool IsRightTriangle => _isRightTriangle.Value;

        public double GetSquare()
        {
            var halfP = (EdgeA + EdgeB + EdgeC) / 2d;
            var square = Math.Sqrt(halfP * (halfP - EdgeA) * (halfP - EdgeB) * (halfP - EdgeC));

            return square;
        }

        /// <exception cref="ArgumentException"></exception>
        private static void CheckValidTriangle(double edgeA, double edgeB, double edgeC)
        {
            CheckEdge(edgeA);
            CheckEdge(edgeB);
            CheckEdge(edgeC);

            CheckingRuleOfTriangleAngles(edgeA, edgeB, edgeC);
        }

        private static void CheckEdge(double edge)
        {
            if (edge < eps)
                throw new ArgumentException("Сторона указана неверно", nameof(edge));
        }


        private static void CheckingRuleOfTriangleAngles(double edgeA, double edgeB, double edgeC)
        {
            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            var perimeter = edgeA + edgeB + edgeC;
            if ((perimeter - maxEdge) - maxEdge < eps)
                throw new ArgumentException("Наибольшая сторона треугольника должна быть меньше суммы других сторон");
        }

        private bool GetIsRightTriangle()
        {
            double maxEdge = EdgeA;
            double b = EdgeB;
            double c = EdgeC;
            if (b - maxEdge > Constants.CalculationAccuracy)
                Utils.Swap(ref maxEdge, ref b);

            if (c - maxEdge > Constants.CalculationAccuracy)
                Utils.Swap(ref maxEdge, ref c);

            return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
        }
    }
}
