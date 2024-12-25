namespace PrototypePattern1
{
    
    public interface ICloneable
    {
        ICloneable Clone();
    }

  
    public class Cube : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }

        public Cube(int x, int y, int z, int size, string color)
        {
            X = x;
            Y = y;
            Z = z;
            Size = size;
            Color = color;
        }

        public ICloneable Clone()
        {
            return new Cube(X, Y, Z, Size, Color);
        }

        public override string ToString()
        {
            return $"Cube: [X={X}, Y={Y}, Z={Z}, Size={Size}, Color={Color}]";
        }
    }

   
    public class Sphere : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }

        public Sphere(int x, int y, int z, int radius, string color)
        {
            X = x;
            Y = y;
            Z = z;
            Radius = radius;
            Color = color;
        }

        public ICloneable Clone()
        {
            return new Sphere(X, Y, Z, Radius, Color);
        }

        public override string ToString()
        {
            return $"Sphere: [X={X}, Y={Y}, Z={Z}, Radius={Radius}, Color={Color}]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Sphere originalSphere = new Sphere(0, 0, 0, 5, "Red");
            Console.WriteLine("Original Sphere: " + originalSphere);

           
            Sphere clonedSphere1 = (Sphere)originalSphere.Clone();
            clonedSphere1.X = 10;
            clonedSphere1.Y = 10;
            clonedSphere1.Color = "Blue";

            Sphere clonedSphere2 = (Sphere)originalSphere.Clone();
            clonedSphere2.X = 20;
            clonedSphere2.Y = 20;
            clonedSphere2.Color = "Green";

         
            Console.WriteLine("Cloned Sphere 1: " + clonedSphere1);
            Console.WriteLine("Cloned Sphere 2: " + clonedSphere2);
            Console.WriteLine("Original Sphere after cloning: " + originalSphere);
        }
    }
}
