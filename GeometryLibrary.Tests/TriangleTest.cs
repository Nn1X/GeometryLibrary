namespace GeometryLibrary.Tests
{
	public class TriangleTest
	{
		[Theory]
		[InlineData(-1, 1, 1)]
		[InlineData(1, -1, 1)]
		[InlineData(1, 1, -1)]
		[InlineData(0, 0, 0)]
		public void InitTriangleWithErrorTest(double a, double b, double c)
		{
			Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
		}

		[Fact]
		public void InitTriangleTest()
		{
			// Arrange.
			double a = 3d, b = 4d, c = 5d;

			// Act.
			var triangle = new Triangle(a, b, c);

			// Assert.
			Assert.NotNull(triangle);

			var aResult = Math.Abs(triangle.EdgeA - a) < Constants.CalculationAccuracy;
			var bResult = Math.Abs(triangle.EdgeB - b) < Constants.CalculationAccuracy;
			var cResult = Math.Abs(triangle.EdgeC - c) < Constants.CalculationAccuracy;

			aResult.ShouldBeOfType<bool>();
			aResult.ShouldBe(true);

			bResult.ShouldBeOfType<bool>();
			bResult.ShouldBe(true);

			cResult.ShouldBeOfType<bool>();
			cResult.ShouldBe(true);
		}

		[Fact]
		public void GetAreaTest()
		{
			// Arrange.
			double a = 3d, b = 4d, c = 5d;
			double expectedValue = 6d;
			var triangle = new Triangle(a, b, c);

			// Act.
			var area = triangle?.GetArea();

			// Assert.
			Assert.NotNull(area);

			var result = Math.Abs(area.Value - expectedValue) < Constants.CalculationAccuracy;

			result.ShouldBeOfType<bool>();
			result.ShouldBe(true);
		}

		[Fact]
		public void InitNotTriangleTest()
		{
			Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 4));
		}
		[Theory]
		[InlineData(3, 4, 3, false)]
		[InlineData(3, 4, 5 + 2e-7, false)]
		[InlineData(3, 4, 5, true)]
		[InlineData(3, 4, 5.000000001, true)]
		public void NotRightTriangle(double a, double b, double c, bool expected)
		{
			// Arrange.
			var triangle = new Triangle(a, b, c);

			// Act.
			var result = triangle.IsRightTriangle;

			// Assert. 
			Assert.Equal(expected, result);
		}
	}
}