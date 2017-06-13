using System;
using System.Text;

namespace TriangleCoordinates
{
	public class Triangle
	{
		public TrianglePoint PointA { get; set; }
		public TrianglePoint PointB { get; set; } //this is the right angle point
		public TrianglePoint PointC { get; set; }
		public string Name { get; set; }

		public Triangle (string name, TrianglePoint pointA, TrianglePoint pointB, TrianglePoint pointC)
		{
			Name = name;
			PointA = pointA;
			PointB = pointB;
			PointC = pointC;
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(PointA.XCoord + "," + PointA.YCoord);
			sb.Append(" ");
			sb.Append(PointB.XCoord + "," + PointB.YCoord);
			sb.Append(" ");
			sb.Append(PointC.XCoord + "," + PointC.YCoord);
			return sb.ToString();
		}
	}
}
