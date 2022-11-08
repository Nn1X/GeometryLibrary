using GeometryLibrary;

namespace GeometryLibrary
{
	public class Circle : IArea
	{
		public const double MinRadius = 1e-6;

		/// <exception cref="ArgumentException"></exception>
		public Circle(double radius)
		{
			CheckCircle(radius);

			Radius = radius;
		}

		public double Radius { get; }

		public double GetArea()
		{
			return Math.PI * Math.Pow(Radius, 2d);
		}
		/// <exception cref="ArgumentException"></exception>
		private static void CheckCircle(double radius)
		{
			if (radius - MinRadius < Constants.CalculationAccuracy)
				throw new ArgumentException("Радиус круга указан неверно", nameof(radius));
		}
	}
}