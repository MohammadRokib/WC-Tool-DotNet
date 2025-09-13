using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_TOOL.IServices.Services
{
    public class CCWC : ICCWC
    {
        private string DIRECTORY;
        public CCWC(string dir)
        {
            DIRECTORY = Path.Combine(dir, "test.txt");
        }

        public void ProcessFile()
        {
            if (File.Exists(DIRECTORY))
            {
                string fileContent = File.ReadAllText(DIRECTORY);
                Console.WriteLine(fileContent);
            }
            else
            {
                Console.WriteLine("File doesn't exist please create the file first");
            }
        }
    }
}
