namespace Quadrilateral
{
    public interface IQuadrilateral
    {
        double GetArea();
        double GetPerimeter();
        string GetQuadrilateralType();
    }
    // Оголошення інтерфейсу для чотирикутника за довжинами сторін
    public interface IQuadrilateralBySides : IQuadrilateral
    {
        double SideA { get; set; }
        double SideB { get; set; }
        double SideC { get; set; }
        double SideD { get; set; }
    }

    // Оголошення інтерфейсу для чотирикутника за координатами вершин
    public interface IQuadrilateralByVertices : IQuadrilateral
    {
        double Vertex1X { get; set; }
        double Vertex1Y { get; set; }
        double Vertex2X { get; set; }
        double Vertex2Y { get; set; }
        double Vertex3X { get; set; }
        double Vertex3Y { get; set; }
        double Vertex4X { get; set; }
        double Vertex4Y { get; set; }
    }

    // Оголошення класу, що реалізує інтерфейс для чотирикутника за довжинами сторін
    public class QuadrilateralBySides : IQuadrilateralBySides
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double SideD { get; set; }

        public double GetArea()
        {
            double s = (SideA + SideB + SideC + SideD) / 2;
            return Math.Sqrt((s - SideA) * (s - SideB) * (s - SideC) * (s - SideD));
        }

        public double GetPerimeter()
        {
            return SideA + SideB + SideC + SideD;
        }

        public string GetQuadrilateralType()
        {
            if (SideA == SideB && SideB == SideC && SideC == SideD)
            {
                return "Square";
            }
            else if ((SideA == SideC && SideB == SideD) || (SideA == SideB && SideC == SideD) || (SideA == SideD && SideB == SideC))
            {
                return "Rectangle or Rhombus";
            }
            else if ((SideA == SideC && SideB != SideD) || (SideA != SideC && SideB == SideD))
            {
                return "Parallelogram";
            }
            else if (SideA != SideB && SideB != SideC && SideC != SideD && ((SideA == SideC && SideB != SideD) || (SideA != SideC && SideB == SideD)))
            {
                return "Trapezoid";
            }
            else
            {
                return "Unknown";
            }
        }
    }

    // Оголошення класу, що реалізує інтерфейс для чотирикутника за координатами вершин
    public class QuadrilateralByVertices : IQuadrilateralByVertices
    {
        public double Vertex1X { get; set; }
        public double Vertex1Y { get; set; }
        public double Vertex2X { get; set; }
        public double Vertex2Y { get; set; }
        public double Vertex3X { get; set; }
        public double Vertex3Y { get; set; }
        public double Vertex4X { get; set; }
        public double Vertex4Y { get; set; }

        public double GetArea()
        {
            // Визначення площі за координатами вершин з використанням формули Гаусса
            double area = 0.5 * Math.Abs((Vertex2X - Vertex1X) * (Vertex3Y - Vertex1Y) - (Vertex3X - Vertex1X) * (Vertex2Y - Vertex1Y));
            area += 0.5 * Math.Abs((Vertex3X - Vertex1X) * (Vertex4Y - Vertex1Y) - (Vertex4X - Vertex1X) * (Vertex3Y - Vertex1Y));
            return area;
        }

        public double GetPerimeter()
        {
            // Визначення периметру за координатами вершин
            double dist1 = Math.Sqrt(Math.Pow(Vertex2X - Vertex1X, 2) + Math.Pow(Vertex2Y - Vertex1Y, 2));
            double dist2 = Math.Sqrt(Math.Pow(Vertex3X - Vertex2X, 2) + Math.Pow(Vertex3Y - Vertex2Y, 2));
            double dist3 = Math.Sqrt(Math.Pow(Vertex4X - Vertex3X, 2) + Math.Pow(Vertex4Y - Vertex3Y, 2));
            double dist4 = Math.Sqrt(Math.Pow(Vertex1X - Vertex4X, 2) + Math.Pow(Vertex1Y - Vertex4Y, 2));
            return dist1 + dist2 + dist3 + dist4;
        }

        public string GetQuadrilateralType()
        {
            double sideA = Math.Sqrt(Math.Pow(Vertex2X - Vertex1X, 2) + Math.Pow(Vertex2Y - Vertex1Y, 2));
            double sideB = Math.Sqrt(Math.Pow(Vertex3X - Vertex2X, 2) + Math.Pow(Vertex3Y - Vertex2Y, 2));
            double sideC = Math.Sqrt(Math.Pow(Vertex4X - Vertex3X, 2) + Math.Pow(Vertex4Y - Vertex3Y, 2));
            double sideD = Math.Sqrt(Math.Pow(Vertex1X - Vertex4X, 2) + Math.Pow(Vertex1Y - Vertex4Y, 2)); if (sideA == sideB && sideB == sideC && sideC == sideD)
            {
                return "Square";
            }
            else if ((sideA == sideC && sideB == sideD) || (sideA == sideB && sideC == sideD) || (sideA == sideD && sideB == sideC))
            {
                return "Rectangle or Rhombus";
            }
            else if ((Vertex1Y - Vertex2Y) / (Vertex1X - Vertex2X) == (Vertex3Y - Vertex4Y) / (Vertex3X - Vertex4X) && (Vertex2Y - Vertex3Y) / (Vertex2X - Vertex3X) == (Vertex4Y - Vertex1Y) / (Vertex4X - Vertex1X))
            {
                return "Parallelogram";
            }
            else if (sideA != sideB && sideB != sideC && sideC != sideD && ((Vertex1Y - Vertex2Y) / (Vertex1X - Vertex2X) == (Vertex3Y - Vertex4Y) / (Vertex3X - Vertex4X) || (Vertex2Y - Vertex3Y) / (Vertex2X - Vertex3X) == (Vertex4Y - Vertex1Y) / (Vertex4X - Vertex1X)))
            {
                return "Trapezoid";
            }
            else
            {
                return "Unknown";
            }
        }
    }
}
