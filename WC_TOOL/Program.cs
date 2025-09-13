using WC_TOOL.IServices;
using WC_TOOL.IServices.Services;

namespace WC_TOOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PathFinder t = new PathFinder();
            ICCWC wc = new CCWC(t.Path());

            wc.ProcessFile();
        }
    }
}
