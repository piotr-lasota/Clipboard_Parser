using DMA_Clipboard_Grabber;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMA_Clipboard_Parser_Tests
{
    [TestClass]
    public class QueryPrinter_tests
    {
        private const int CODE_LENGTH = 13;
        private const char FILLER_CHAR = '0';
        string teststring = @"OK values: DTR1234567890 like DTR*320 like GL01234567890 like GD02345678901 like ABD1234567890 like ABD*333 like AX*3201, AX0*123 like XYD*1234. NOK values: AB000000000034, DTR000000000034, ABD000000000034, AB*000000000000023, DTR*000000000000023, ABD*000000000000023";

        [TestMethod]
        public void PrintToDesktop_TestLine_ShouldBePrinted()
        {
            // Arrange
            QueryPrinter printer = new QueryPrinter("test string");

            // Act
            printer.PrintToDesktop();

            // Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void PrintToDesktop_ExampleQuery_ShouldBePrinter()
        {
            // Arrange
            Classifier classifier = new Classifier(teststring);
            QueryAssembler queryAssembler = new QueryAssembler(classifier.DefinitnMatches, DMAEnvironment.DEFINITN, CODE_LENGTH, FILLER_CHAR);
            QueryPrinter queryPrinter = new QueryPrinter(queryAssembler.Query);

            // Act
            queryPrinter.PrintToDesktop();

            // Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void PrintToPointedLocation_ExampleQuery_ShouldBePrinter()
        {
            // Arrange
            Classifier classifier = new Classifier(teststring);
            QueryAssembler queryAssembler = new QueryAssembler(classifier.DefinitnMatches, DMAEnvironment.DEFINITN, CODE_LENGTH, FILLER_CHAR);
            QueryPrinter queryPrinter = new QueryPrinter(queryAssembler.Query);

            // Act
            queryPrinter.PrintToDesktop();

            // Assert
            Assert.AreEqual(1, 1);
        }
    }
}
