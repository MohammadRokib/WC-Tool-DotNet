using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_TOOL.IServices.Services
{
    public class CCWC : ICCWC
    {
        private string DIRECTORY = String.Empty;
        private string FileContent = String.Empty;
        private string Group = String.Empty;
        private string Option = String.Empty;
        private string FileName = String.Empty;

        public CCWC(string input)
        {
            ParseInput(input);
            GetPath();
        }

        public void ProcessFile()
        {
            if (!LoadFile())
                return;

            long result = 0;

            switch (Option)
            {
                case "-c":
                    result = CountBytes();
                    break;
                case "-l":
                    CountLines();
                    break;
                case "-m":
                    CountChars();
                    break;
                case "-w":
                    CountWords();
                    break;
                default:
                    DefaultCount();
                    break;
            }

            Console.WriteLine($"{result} {FileName}");
        }

        private long CountBytes()
        {
            Console.WriteLine("Counting bytes");
            //byte[] bytes = Encoding.UTF8.GetBytes(FileContent);
            //return bytes.Length;
            return new FileInfo(DIRECTORY).Length;
        }

        private void CountLines()
        {
            Console.WriteLine("Counting Lines");
        }

        private void CountWords()
        {
            Console.WriteLine("Counting Words");
        }

        private void CountChars()
        {
            Console.WriteLine("Counting Lines");
        }

        private void DefaultCount()
        {
            Console.WriteLine("No option selected");
        }

        private void GetPath()
        {
            try
            {
                DIRECTORY = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString();
                DIRECTORY = Path.Combine(DIRECTORY, FileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private bool LoadFile()
        {
            if (!File.Exists(DIRECTORY))
            {
                Console.WriteLine("File not found");
                return false;
            }

            FileContent = File.ReadAllText(DIRECTORY);
            Console.WriteLine("File Read Complete");
            return true;
        }

        private void ParseInput(String input)
        {
            String[] inputParts = input.Split(' ');
            if (inputParts[0].Equals("ccwc", StringComparison.OrdinalIgnoreCase))
            {
                Group = inputParts[0];
                Option = inputParts[1];
                FileName = inputParts[2];
            }
            else
            {
                Console.WriteLine("Invalid command format. Use: ccwc [option] [filename]");
            }
        }
    }
}
