

namespace GeometryLibrary.Test
{
    public class CircleTest
    {
		private const double eps = 1e-7;

		[Fact]
		public void ZeroRadiusTest()
		{
			Assert.Throws<ArgumentException>(() => new Circle(0d));
		}


		[Fact]
		public void NegativeRadiusTest()
		{
			Assert.Throws<ArgumentException>(() => new Circle(-1d));
		}


		[Fact]
		public void LessMinRadiusTest()
		{
			Assert.Throws<ArgumentException>(() => new Circle(Circle.MinRadius - 1e7));
		}


		[Fact]
		public void GetSquareTest()
		{
			var radius = 5;
			var circle = new Circle(radius);
			var expectedValue = Math.PI * Math.Pow(radius, 2d);

			var square = circle.GetSquare();

			var result = Math.Abs(square - expectedValue) < eps;

			result.ShouldBeOfType<bool>();
			result.ShouldBe(true);
		}
	}
}
