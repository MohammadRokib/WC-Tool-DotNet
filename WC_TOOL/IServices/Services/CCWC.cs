using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WC_TOOL.IServices.Services
{
    public class CCWC : ICCWC
    {
        private string Flag = String.Empty;
        private string Command = String.Empty;
        private string FileName = String.Empty;
        private string DIRECTORY = String.Empty;
        private string FileContent = String.Empty;

        public CCWC(string input)
        {
            ProcessFile(input);
        }

        public void ProcessFile(string input)
        {
            if (!ParseInput(input))
                return;

            if (!GetPath())
                return;

            if (!LoadFile())
                return;

            long result = 0;

            switch (Flag)
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

            if (!String.IsNullOrEmpty(Flag))
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
            Console.WriteLine($"{CountLines()} {CountWords()} {CountBytes()} {FileName}");
        }

        private bool GetPath()
        {
            try
            {
                if (Path.IsPathRooted(FileName))
                {
                    DIRECTORY = FileName;
                }
                else
                {
                    DIRECTORY = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.ToString();
                    DIRECTORY = Path.Combine(DIRECTORY, "WC_TOOL", FileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private bool LoadFile()
        {
            if (!File.Exists(DIRECTORY))
            {
                Console.WriteLine("File not found");
                return false;
            }

            FileContent = File.ReadAllText(DIRECTORY);
            return true;
        }

        private bool ParseInput(String input)
        {
            String[] inputParts = input.Split(' ');
            string pattern = @"^(?:cat\s+(?<file>\S+)\s*\|\s*)?ccwc(?:\s+(?<flag>-\w))?(?:\s+(?<file2>\S+))?$";

            var match = Regex.Match(input.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                Flag = match.Groups["flag"].Value;
                FileName = match.Groups["file2"].Value;
                string pipeFile = match.Groups["file"].Value;

                Command = input.StartsWith("cat", StringComparison.OrdinalIgnoreCase) ? "cat" : "ccwc";
                FileName = !String.IsNullOrEmpty(pipeFile) ? pipeFile : FileName;
            }
            else
            {
                Console.WriteLine("Invalid command format. Use: ccwc [option] [filename]");
                return false;
            }

            return true;
        }
    }
}
