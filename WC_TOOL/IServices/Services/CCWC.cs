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
                    result = CountLines();
                    break;
                case "-m":
                    result = CountChars();
                    break;
                case "-w":
                    result = CountWords();
                    break;
                default:
                    DefaultCount();
                    break;
            }

            Console.WriteLine($"{result} {FileName}");
        }

        public long CountBytes()
        {
            return new FileInfo(DIRECTORY).Length;
        }

        public long CountLines()
        {
            long lineCount = 0;
            using (StreamReader sr = new StreamReader(DIRECTORY))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    lineCount++;
                }
            }
            return lineCount;
        }

        public long CountWords()
        {
            long wordCount = 0;
            bool inWord = false;

            using (StreamReader sr = new StreamReader(DIRECTORY))
            {
                int charCode;
                while ((charCode = sr.Read()) != -1)
                {
                    char ch = (char)charCode;
                    if (char.IsWhiteSpace(ch))
                    {
                        if (inWord)
                        {
                            wordCount++;
                            inWord = false;
                        }
                    }
                    else
                    {
                        inWord = true;
                    }
                }

                if (inWord)
                    wordCount++;
            }
            return wordCount;
        }

        public long CountChars()
        {
            Console.WriteLine("Counting Lines");
            long charCount = 0;

            using (StreamReader sr = new StreamReader(DIRECTORY))
            {
                int charCode;
                while ((charCode = sr.Read()) != -1)
                {
                    charCount++;
                }
            }
            return charCount;
        }

        private void DefaultCount()
        {
            Console.WriteLine("No option selected");
        }

        private void GetPath()
        {
            try
            {
                DIRECTORY = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.ToString();
                DIRECTORY = Path.Combine(DIRECTORY, "WC_TOOL", FileName);
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
