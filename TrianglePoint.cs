using System;

namespace TriangleCoordinates
{
	public class TrianglePoint
	{
		public int XCoord { get; set; }
		public int YCoord { get; set; }

		public TrianglePoint(int RowNum, int ColNum)
		{
			//think these need switched
			XCoord = ColNum;
			YCoord = RowNum;
		}
	}
}
