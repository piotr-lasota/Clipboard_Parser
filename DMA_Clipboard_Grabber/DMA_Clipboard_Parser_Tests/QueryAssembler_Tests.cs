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
        public void Constructor_SingleCode_ShouldProduceOneLiner()
        {
            // arange
            List<string> input = new List<string> { "AX*1234", "AB*3333" };
            string environment = "DEFINITN";
            string expectedResult = "Placeholder";

            // act
            QueryAssembly queryAssembly = new QueryAssembly(input, environment);

            // assert
            Assert.AreEqual<String>(expectedResult, queryAssembly.Query);
        }
    }
}
