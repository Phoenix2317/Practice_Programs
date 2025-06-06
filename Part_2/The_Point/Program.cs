internal class Program
{
    private static void Main(string[] args)
    {
        Point Position1 = new Point(2, 3);
        Point Position2 = new Point(-4, 0);
        Console.WriteLine($"The first point is located at:  ({Position1.x}, {Position1.y})");
        Console.WriteLine($"The second point is located at: ({Position2.x}, {Position2.y})");
    }

    class Point
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Point(int x, int y) 
        { 
            this.x = x;
            this.y = y;
        }

        public Point() 
        {
            this.x = 0;
            this.y = 0;
        }


    }
}