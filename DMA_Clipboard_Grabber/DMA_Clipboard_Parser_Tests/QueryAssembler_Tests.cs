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
            DMAEnvironment environment = DMAEnvironment.DEFINITN;
            string expectedResult = "#CDMA.CATCON.DEFINITN.PART\r\n" +
                "PART_LIST;S_PART_NUMBER;WITH;AX00000001234;;";
                
            // act
            QueryAssembler queryAssembly = new QueryAssembler(input, environment, 13, '0');

            // assert
            Assert.AreEqual<String>(expectedResult, queryAssembly.Query);
        }

        [TestMethod]
        public void Constructor_MultipleCodes_ShouldMatch()
        {
            // arange
            List<string> input = new List<string> { "AX*1234", "AB*3333", "AB*4444" };
            DMAEnvironment environment = DMAEnvironment.DEFINITN;
            string expectedResult = "#CDMA.CATCON.DEFINITN.PART\r\n" +
                "PART_LIST;S_PART_NUMBER;WITH;AX00000001234;;\r\n" +
                "PART_LIST;S_PART_NUMBER;WITH;AB00000003333;;\r\n" +
                "PART_LIST;S_PART_NUMBER;WITH;AB00000004444;;\r\n" +
                "OR\r\n"+
                "OR";

            // act
            QueryAssembler queryAssembly = new QueryAssembler(input, environment, 13, '0');

            // assert
            Assert.AreEqual<String>(expectedResult, queryAssembly.Query);
        }
    }
}
