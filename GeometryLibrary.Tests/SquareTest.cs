using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary.Tests
{
    public class SquareTest
    {
		private const double eps = 1e-7;

        [Fact]
		public void GetSquareTest()
		{
            #region Circle
            var radius = 5d;
			var expectedCircleValue = Math.PI * Math.Pow(radius, 2d);
			ISquare sqCircle = new Circle(radius);
			var squareCircle = Square.GetSquare(sqCircle);

			var circleResult = Math.Abs(squareCircle - expectedCircleValue) < eps;

			circleResult.ShouldBeOfType<bool>();
			circleResult.ShouldBe(true);
			#endregion

			#region Triangle
			double a = 3d, b = 4d, c = 5d;
			double expectedTriangleValue = 6d;
			ISquare sqTriangle = new Triangle(a, b, c);

			var squareTriangle = Square.GetSquare(sqTriangle);

			var triangleResult = Math.Abs(squareTriangle - expectedTriangleValue) < Constants.CalculationAccuracy;

			triangleResult.ShouldBeOfType<bool>();
			triangleResult.ShouldBe(true);
			#endregion
		}
	}
}
