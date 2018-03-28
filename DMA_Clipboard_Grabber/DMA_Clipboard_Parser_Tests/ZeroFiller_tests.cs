using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMA_Clipboard_Grabber;

namespace DMA_Clipboard_Parser_Tests
{
    [TestClass]
    public class ZeroFiller_tests
    {
        [TestMethod]
        public void ZeroFiller_ShortCode_ShouldBeFilled()
        {
            // arrange
            string input = "AB*7890";
            string expectedOutput = "AB00000007890";

            // act
            string output = ZeroFiller.fillToDigits(input, 13, '0');
            // assert
            Assert.AreEqual<String>(expectedOutput, output);
        }

        [TestMethod]
        public void ZeroFiller_SmallLetterShortCode_ShouldBeCapitalized()
        {
            // arrange
            string input = "ab0*7890";
            string expectedOutput = "AB00000007890";

            // act
            string output = ZeroFiller.fillToDigits(input, 13, '0');
            // assert
            Assert.AreEqual<String>(expectedOutput, output);
        }

        [TestMethod]
        public void ZeroFiller_SmallLetterFullCode_ShouldBeCapitalized()
        {
            // arrange
            string input = "ab00000007890";
            string expectedOutput = "AB00000007890";

            // act
            string output = ZeroFiller.fillToDigits(input, 13, '0');
            // assert
            Assert.AreEqual<String>(expectedOutput, output);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ZeroFiller_TooLongInput_ShouldThrowFormatException()
        {
            // arrange
            string input = "AB000000007890"; // one too many

            // act
            string output = ZeroFiller.fillToDigits(input, 13, '0');
            
            // assert handled by ExpectedException
        }
    }
}
