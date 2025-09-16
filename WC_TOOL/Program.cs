using WC_TOOL.IServices;
using WC_TOOL.IServices.Services;

namespace WC_TOOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String input = String.Empty;
            while (String.IsNullOrWhiteSpace(input))
            {
                input = Console.ReadLine()!;
            }
            
            ICCWC wc = new CCWC(input);
        }
    }
}
