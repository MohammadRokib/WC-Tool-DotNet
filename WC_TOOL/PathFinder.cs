using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_TOOL
{
    public class PathFinder
    {
        private String PATH { get; } = String.Empty;
        public PathFinder()
        {
            try
            {
                DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
                PATH = path!.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public String Path()
        {
            return PATH;
        }
    }
}
