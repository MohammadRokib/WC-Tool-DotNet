using WC_TOOL.IServices;
using WC_TOOL.IServices.Services;

namespace WC_TOOL.Tests
{
    public class CCWCTest
    {
        [Fact]
        public void CountBytesTest()
        {
            ICCWC ccwc = new CCWC("ccwc -w test.txt");
            long result = ccwc.CountBytes();

            Assert.Equal(342190, result);
        }

        [Fact]
        public void CountCharsTest()
        {
            ICCWC ccwc = new CCWC("ccwc -w test.txt");
            long result = ccwc.CountChars();

            Assert.Equal(339291, result);
        }

        [Fact]
        public void CountLinesTest()
        {
            ICCWC ccwc = new CCWC("ccwc -w test.txt");
            long result = ccwc.CountLines();

            Assert.Equal(7145, result);
        }

        [Fact]
        public void CountWordsTest()
        {
            ICCWC ccwc = new CCWC("ccwc -w test.txt");
            long result = ccwc.CountWords();

            Assert.Equal(58164, result);
        }
    }
}