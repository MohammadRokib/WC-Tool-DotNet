using WC_TOOL.IServices;
using WC_TOOL.IServices.Services;

namespace WC_TOOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String input = String.Empty;
            while (input is null || input == String.Empty)
            {
                input = Console.ReadLine()!;
                ICCWC wc = new CCWC(input);
            }
        }
    }
}
