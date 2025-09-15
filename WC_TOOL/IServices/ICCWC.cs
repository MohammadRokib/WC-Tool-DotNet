using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_TOOL.IServices
{
    public interface ICCWC
    {
        public void ProcessFile();
        public long CountBytes();
        public long CountLines();
        public long CountWords();
        public long CountChars();
    }
}
