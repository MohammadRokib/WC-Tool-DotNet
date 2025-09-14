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
            GetContent();
            ProcessFile();
        }

        public void ProcessFile()
        {
            switch (Option)
            {
                case "-c":
                    CountBytes();
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
        }

        private void CountBytes()
        {
            Console.WriteLine("Counting bytes");
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

        private void GetContent()
        {
            if (File.Exists(DIRECTORY))
            {
                FileContent = File.ReadAllText(DIRECTORY);
                Console.WriteLine("File read complete");
            }
            else
            {
                Console.WriteLine("File doesn't exist please create the file first");
            }
        }

        private void ParseInput(String input)
        {
            String[] inputParts = input.Split(' ');
            if (inputParts[0].ToUpper() == ("ccwc").ToUpper())
            {
                Group = inputParts[0];
                Option = inputParts[1];
                FileName = inputParts[2];
            }
            else
            {
                Console.WriteLine("other option");
            }
        }
    }
}
