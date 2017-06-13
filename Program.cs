using System;

namespace TriangleCoordinates
{
	class Program
	{
		static void Main(string[] args)
		{
			/*			 
			 Multi dimensional array [6] [6] 
			 inside each cell is a SquareCell
				in side each SquareCell are two triangles which are really just points
					Triangle is 3 Points x,y x,y x,y, 0,0 0,1 1,1 and a name for fun
						Triangle needs a method to determine if it is found or not found
							match on points
					create a Point object
			create nested loops to load SquareCell with 2 triangles	
				create a SquareCell with 2 triangles and an x,y in the array
					new triangle - x,y x,y+1 x+1,y+1
					new triangle - x,y x+1,y x+1,y+1

			after loading the grid take a set of points and find the cell it is in
				really you already have that information just from the coordinates
				probably a simple algorithm on base 10

				use cases
					0,0		10,0	10,10
					11,11	11,20	20,20
					51,51	51,60	60,60

					-1,0	10,0	10,10
					51,51	51,60	61,61

				really you just need the last point to know the cell it is in
					check it is not <0 and not > 60 (keep it in the grid)
			 */

			SquareCell[,] array = new SquareCell[6, 6];
			int xLength = array.GetLength(0);
			int yLength = array.GetLength(1);

			for (int rowNum = 0; rowNum < yLength; rowNum++)
			{
				for(int colNum = 0; colNum < xLength; colNum++)
				{
					SquareCell sc = new SquareCell();

					Triangle triEven = new Triangle(rowNum + "," + colNum, new TrianglePoint(rowNum*10, colNum*10), new TrianglePoint((rowNum+1)*10, colNum*10), new TrianglePoint((rowNum+1) * 10, (colNum+1) * 10));
					Triangle triOdd = new Triangle(rowNum + "," + colNum, new TrianglePoint(rowNum* 10, colNum*10), new TrianglePoint((rowNum)*10, (colNum+1)*10), new TrianglePoint((rowNum+1) * 10, (colNum+1) * 10));

					sc.TriangleEven = triEven;
					sc.TriangleOdd = triOdd;
					array[rowNum, colNum] = sc;
				}
			}

			for (int rowNum = 0; rowNum < yLength; rowNum++)
			{
				for (int colNum = 0; colNum < xLength; colNum++)
				{
					SquareCell sc = array[rowNum, colNum];
					//Console.Write(sc.TriangleEven.Name + "\\" + sc.TriangleOdd.Name + " ");
					Console.Write(sc.TriangleEven + "\\" + sc.TriangleOdd +" ");
				}
				Console.Write(System.Environment.NewLine);
			}

			//now create a method that can look through the array for a special triangle
			//and return the cell coordinates (row and column)
			//or just have it take the last value and return the cell's info

			Console.Write(System.Environment.NewLine);

			Triangle Test1 = new Triangle("Test1", new TrianglePoint(0, 0), new TrianglePoint(10, 0), new TrianglePoint(10, 10));
			Console.WriteLine(Test1);
			Console.WriteLine(WhereIsThisTriange(Test1));
			Console.Write(System.Environment.NewLine);

			Triangle Test2 = new Triangle("Test2", new TrianglePoint(-10, 0), new TrianglePoint(10, 0), new TrianglePoint(10, 10));
			Console.WriteLine(Test2);
			Console.WriteLine(WhereIsThisTriange(Test2));
			Console.Write(System.Environment.NewLine);

			Triangle Test3 = new Triangle("Test3", new TrianglePoint(50, 50), new TrianglePoint(50, 60), new TrianglePoint(59, 59));
			Console.WriteLine(Test3);
			Console.WriteLine(WhereIsThisTriange(Test3));
			Console.Write(System.Environment.NewLine);

			Triangle Test4 = new Triangle("Test4", new TrianglePoint(50, 50), new TrianglePoint(50, 60), new TrianglePoint(600, 60));
			Console.WriteLine(Test4);
			Console.WriteLine(WhereIsThisTriange(Test4));
		}

		private static string WhereIsThisTriange(Triangle test1)
		{
			string result = "Triangle not in range!";
			if ((test1.PointA.XCoord >= 0 && test1.PointA.XCoord <= 60) &&
				 (test1.PointA.YCoord >= 0 && test1.PointA.YCoord <= 60) &&
				 (test1.PointB.XCoord >= 0 && test1.PointB.XCoord <= 60) &&
				  (test1.PointB.YCoord >= 0 && test1.PointB.YCoord <= 60) &&
				 (test1.PointC.XCoord >= 0 && test1.PointC.XCoord <= 60) &&
				  (test1.PointC.YCoord >= 0 && test1.PointC.YCoord <= 60)
				)
			{
				result = "Row = " + ((test1.PointA.YCoord / 10)+1) + "Column = " + ((test1.PointA.XCoord / 10)+1);
			}

			return result;
		}
	}
}
