using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary.Tests
{
    public class AreaTest
    {
		private const double eps = 1e-7;

        [Fact]
		public void GetAreaTest()
		{
            #region Circle
            var radius = 5d;
			var expectedCircleValue = Math.PI * Math.Pow(radius, 2d);
			IArea arCircle = new Circle(radius);
			var areaCircle = Area.GetArea(arCircle);

			var circleResult = Math.Abs(areaCircle - expectedCircleValue) < eps;

			circleResult.ShouldBeOfType<bool>();
			circleResult.ShouldBe(true);
			#endregion

			#region Triangle
			double a = 3d, b = 4d, c = 5d;
			double expectedTriangleValue = 6d;
			IArea arTriangle = new Triangle(a, b, c);

			var areaTriangle = Area.GetArea(arTriangle);

			var triangleResult = Math.Abs(areaTriangle - expectedTriangleValue) < Constants.CalculationAccuracy;

			triangleResult.ShouldBeOfType<bool>();
			triangleResult.ShouldBe(true);
			#endregion
		}
	}
}
