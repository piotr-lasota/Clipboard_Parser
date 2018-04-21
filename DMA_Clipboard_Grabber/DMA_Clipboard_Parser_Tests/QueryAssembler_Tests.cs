using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMA_Clipboard_Grabber;
using System.Collections.Generic;

namespace DMA_Clipboard_Parser_Tests
{
    [TestClass]
    public class QueryAssembler_tests
    {
        [TestMethod]
        public void Constructor_SingleLiner_ShouldMatch()
        {
            // arange
            List<string> input = new List<string> { "AX*1234" };
            string environment = "DEFINITN";
            string expectedResult = "#CDMA.CATCON.DEFINITN.PART\r\n" +
                "PART_LIST;S_PART_NUMBER;WITH;AX00000001234;;";
                
            // act
            QueryAssembly queryAssembly = new QueryAssembly(input, environment, 13, '0');

            // assert
            Assert.AreEqual<String>(expectedResult, queryAssembly.Query);
        }

        [TestMethod]
        public void Constructor_TwoCodes_ShouldMatch()
        {
            // arange
            List<string> input = new List<string> { "AX*1234", "AB*3333" };
            string environment = "DEFINITN";
            string expectedResult = "#CDMA.CATCON.DEFINITN.PART\r\n" +
                "PART_LIST;S_PART_NUMBER;WITH;AX00000001234;;\r\n" +
                "OR\r\n" +
                "PART_LIST;S_PART_NUMBER;WITH;AB00000003333;;";

            // act
            QueryAssembly queryAssembly = new QueryAssembly(input, environment, 13, '0');

            // assert
            Assert.AreEqual<String>(expectedResult, queryAssembly.Query);
        }
    }
}
