using System;
using System.Linq;
using DMA_Clipboard_Grabber;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMA_Clipboard_Parser_Tests
{
    [TestClass]
    public class Classifier_tests
    {
        #region Testing data
        // Test string
        string teststring = @"OK values: DTR1234567890 like DTR*320 like GL01234567890 like GD02345678901 like ABD1234567890 like ABD*333 like AX*3201, AX0*123 like XYD*1234. NOK values: AB000000000034, DTR000000000034, ABD000000000034, AB*000000000000023, DTR*000000000000023, ABD*000000000000023";

        // Outputs expected of the string.
        string[] DTRoutput = { "DTR1234567890", "DTR*320" };
        string[] DESIGNoutput = { "ABD*333", "ABD1234567890", "XYD*1234" };
        string[] DEFINITNoutput = { "GL01234567890", "GD02345678901", "AX*3201", "AX0*123" };
        string[] FOLDERoutput = { "GL01234567890", "GD02345678901", "AX*3201", "AX0*123" };
        string[] TooLongDefinitn = { "AB000000000034", "AB*000000000000023" };
        string[] TooLongDTR = { "DTR*000000000000023", "DTR000000000034"};
        string[] TooLongDesign = { "ABD000000000034", "ABD*000000000000023" };
        #endregion

        #region DTR
        [TestMethod]
        public void Constructor_FullNumberDTR_ShouldMatchCommerce()
        {
            //// arrange
            string[] expectedMatches = { "DTR1234567890" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.CommerceMatches);
        }

        [TestMethod]
        public void Constructor_AsteriskDTR_ShouldMatchCommerce()
        {
            //// arrange
            string[] expectedMatches = { "DTR*320" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.CommerceMatches);
        }

        [TestMethod]
        public void Constructor_TooLongAsteriskDTR_ShouldNotMatchCommerce()
        {
            //// arrange
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            foreach(string input in TooLongDTR)
            {
                CollectionAssert.DoesNotContain(classifier.CommerceMatches, input);
            }
        }
        #endregion

        #region Design
        [TestMethod]
        public void Constructor_FullNumberDesign_ShouldMatchDesign()
        {
            //// arrange
            string[] expectedMatches = { "ABD1234567890" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DesignMatches);
        }

        [TestMethod]
        public void Constructor_AsteriskDesign_ShouldMatchDesign()
        {
            //// arrange
            string[] expectedMatches = { "ABD*333", "XYD*1234" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DesignMatches);
        }

        [TestMethod]
        public void Constructor_TooLongAsteriskDesign_ShouldNotMatchDesign()
        {
            //// arrange
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            foreach (string input in TooLongDesign)
            {
                CollectionAssert.DoesNotContain(classifier.DesignMatches, input);
            }
        }
        #endregion

        #region Definitn
        [TestMethod]
        public void Constructor_FullNumberDefinitn_ShouldMatchDefinitn()
        {
            //// arrange
            string[] expectedMatches = { "GL01234567890", "GD02345678901" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DefinitnMatches);
        }
        [TestMethod]
        public void Constructor_AsteriskDefinitn_ShouldMatchDefinitn()
        {
            //// arrange
            string[] expectedMatches = { "AX*3201", "AX0*123" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DefinitnMatches);
        }

        [TestMethod]
        public void Constructor_TooLongAsteriskDefinitn_ShouldNotMatchDefinitn()
        {
            //// arrange
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            foreach (string input in TooLongDefinitn)
            {
                CollectionAssert.DoesNotContain(classifier.DefinitnMatches, input);
            }
        }
        #endregion

        #region Folder

        [TestMethod]
        public void Constructor_AsteriskDefinitn_ShouldMatchFolder()
        {
            //// arrange
            string[] expectedMatches = { "AX*3201", "AX0*123" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.FolderMatches);
        }

        [TestMethod]
        public void Constructor_FullNumberDefinitn_ShouldMatchFolder()
        {
            //// arrange
            string[] expectedMatches = { "GL01234567890", "GD02345678901" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.FolderMatches);
        }

        [TestMethod]
        public void Constructor_TooLongAsteriskDefinitn_ShouldNotMatchFolder()
        {
            //// arrange
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            foreach (string input in TooLongDefinitn)
            {
                CollectionAssert.DoesNotContain(classifier.DefinitnMatches, input);
            }
        }
        #endregion
    }
}
