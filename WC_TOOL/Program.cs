namespace WC_TOOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PathFinder t = new PathFinder();
            String directory = t.Path();

            Console.WriteLine(directory);
        }
    }
}
