using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMA_Clipboard_Grabber;
using System.Collections.Generic;

namespace DMA_Clipboard_Parser_Tests
{
    [TestClass]
    public class StringFill_tests
    {
        [TestMethod]
        public void FillStringToLength_ShortCode_ShouldBeFilled()
        {
            // arrange
            string input = "AB*7890";
            string expectedOutput = "AB00000007890";

            // act
            string output = StringFill.FillStringToLength(input, 13, '0');
            // assert
            Assert.AreEqual<String>(expectedOutput, output);
        }

        [TestMethod]
        public void FillStringToLength_SmallLetterShortCode_ShouldBeCapitalized()
        {
            // arrange
            string input = "ab0*7890";
            string expectedOutput = "AB00000007890";

            // act
            string output = StringFill.FillStringToLength(input, 13, '0');
            // assert
            Assert.AreEqual<String>(expectedOutput, output);
        }

        [TestMethod]
        public void FillStringToLength_SmallLetterFullCode_ShouldBeCapitalized()
        {
            // arrange
            string input = "ab00000007890";
            string expectedOutput = "AB00000007890";

            // act
            string output = StringFill.FillStringToLength(input, 13, '0');
            // assert
            Assert.AreEqual<String>(expectedOutput, output);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FillStringToLength_TooLongInput_ShouldThrowFormatException()
        {
            // arrange
            string input = "AB000000007890"; // one too many

            // act
            string output = StringFill.FillStringToLength(input, 13, '0');
            
            // assert handled by ExpectedException
        }

        [TestMethod]
        public void FillListToLength_SmallLetterShortCodes_ShouldBeFilled()
        {
            // arrange
            List<string> inputList = new List<string> { "abc*123", "defg*5556" };
            List<string> desiredOutput = new List<string> { "ABC0000000123", "DEFG000005556" };

            // act
            List<string> output = StringFill.FillListToLength(inputList, 13, '0');

            // assert
            CollectionAssert.AreEqual(desiredOutput, output);
        }

        [TestMethod]
        public void FillListToLength_SmallLetterFullCode_ShouldBeCapitalized()
        {
            // arrange
            List<string> inputList = new List<string> { "abc0000000123", "defg000005556" };
            List<string> desiredOutput = new List<string> { "ABC0000000123", "DEFG000005556" };

            // act
            List<string> output = StringFill.FillListToLength(inputList, 13, '0');

            // assert
            CollectionAssert.AreEqual(desiredOutput, output);
        }

        [TestMethod]
        public void FillListToLength_VariableLengthCodes_ShouldBeProcessed()
        {
            // arrange
            List<string> inputList = new List<string> { "abc*00123", "defg*005556" };
            List<string> desiredOutput = new List<string> { "ABC0000000123", "DEFG000005556" };

            // act
            List<string> output = StringFill.FillListToLength(inputList, 13, '0');

            // assert
            CollectionAssert.AreEqual(desiredOutput, output);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FillListToLength_TooLongInput_ShouldThrowFormatException()
        {
            // arrange
            List<string> inputList = new List<string> { "abc0000000000123", "defg000005556" };

            // act
            List<string> output = StringFill.FillListToLength(inputList, 13, '0');

            // assert
            // handled by the exception
        }


    }
}
