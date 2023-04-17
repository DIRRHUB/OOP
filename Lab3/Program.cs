
using Quadrilateral;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Choose method of quadrilateral creation:");
        Console.WriteLine("1. By sides");
        Console.WriteLine("2. By vertices");

        int choice = int.Parse(s: Console.ReadLine() ?? "1");

        IQuadrilateral quadrilateral;

        if (choice == 1)
        {
            Console.WriteLine("Enter lengths of sides A, B, C, D:");

            double sideA = double.Parse(s: Console.ReadLine() ?? "0");
            double sideB = double.Parse(s: Console.ReadLine() ?? "0");
            double sideC = double.Parse(s: Console.ReadLine() ?? "0");
            double sideD = double.Parse(s: Console.ReadLine() ?? "0");

            if (sideA > 0 && sideB > 0 && sideC > 0 && sideD > 0)
            {
                Console.WriteLine("Wrong lengths of sides");
            }

            quadrilateral = new QuadrilateralBySides
            {
                SideA = sideA,
                SideB = sideB,
                SideC = sideC,
                SideD = sideD
            };
        }
        else if (choice == 2)
        {
            Console.WriteLine("Enter coordinates of vertices:");

            double vertex1X = double.Parse(s: Console.ReadLine() ?? "0");
            double vertex1Y = double.Parse(s: Console.ReadLine() ?? "0");
            double vertex2X = double.Parse(s: Console.ReadLine() ?? "0");
            double vertex2Y = double.Parse(s: Console.ReadLine() ?? "0");
            double vertex3X = double.Parse(s: Console.ReadLine() ?? "0");
            double vertex3Y = double.Parse(s: Console.ReadLine() ?? "0");
            double vertex4X = double.Parse(s: Console.ReadLine() ?? "0");
            double vertex4Y = double.Parse(s: Console.ReadLine() ?? "0");

            quadrilateral = new QuadrilateralByVertices
            {
                Vertex1X = vertex1X,
                Vertex1Y = vertex1Y,
                Vertex2X = vertex2X,
                Vertex2Y = vertex2Y,
                Vertex3X = vertex3X,
                Vertex3Y = vertex3Y,
                Vertex4X = vertex4X,
                Vertex4Y = vertex4Y
            };
        }
        else
        {
            Console.WriteLine("Invalid choice. Program will exit.");
            return;
        }

        double area = quadrilateral.GetArea();
        double perimeter = quadrilateral.GetPerimeter();
        string quadrilateralType = quadrilateral.GetQuadrilateralType();

        Console.WriteLine($"Area: {area}, Perimeter: {perimeter}, Type: {quadrilateralType}");

    }
}

