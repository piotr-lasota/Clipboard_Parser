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
        string teststring = @"DTR1234567890 jest numerem, z którym sporo osób ma (pewne) problemy. Podobnie DTR*320. Wszystko mamy jednak w geometriach GL01234567890 i GD02345678901. Doliczamy sobie do tego ABD1234567890 ABD*333 i ich party AX*3201, AX0*123 oraz i XYD*1234 jest komplet.";

        // Outputs expected of the string.
        string[] DTRoutput = { "DTR1234567890", "DTR*320" };
        string[] DESIGNoutput = { "ABD*333", "ABD1234567890", "XYD*1234" };
        string[] DEFINITNoutput = { "GL01234567890", "GD02345678901", "AX*3201", "AX0*123" };
        string[] FOLDERoutput = { "GL01234567890", "GD02345678901", "AX*3201", "AX0*123" };
        #endregion

        #region DTR
        [TestMethod]
        public void Classifier_FullNumberDTR_ShouldMatchCommerce()
        {
            //// arrange
            string[] expectedMatches = { "DTR1234567890" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.CommerceMatches);
        }

        [TestMethod]
        public void Classifier_AsteriskDTR_ShouldMatchCommerce()
        {
            //// arrange
            string[] expectedMatches = { "DTR*320" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.CommerceMatches);
        }
        #endregion

        #region Design
        [TestMethod]
        public void Classifier_FullNumberDesign_ShouldMatchDesign()
        {
            //// arrange
            string[] expectedMatches = { "ABD1234567890" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DesignMatches);
        }

        [TestMethod]
        public void Classifier_AsteriskDesign_ShouldMatchDesign()
        {
            //// arrange
            string[] expectedMatches = { "ABD*333", "XYD*1234" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DesignMatches);
        }
        #endregion

        #region Definitn
        [TestMethod]
        public void Classifier_FullNumberDefinitn_ShouldMatchDefinitn()
        {
            //// arrange
            string[] expectedMatches = { "GL01234567890", "GD02345678901" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DefinitnMatches);
        }

        [TestMethod]
        public void Classifier_AsteriskDefinitn_ShouldMatchDefinitn()
        {
            //// arrange
            string[] expectedMatches = { "AX*3201", "AX0*123" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.DefinitnMatches);
        }
        #endregion

        #region Folder
        public void Classifier_FullNumberDefinitn_ShouldMatchFolder()
        {
            //// arrange
            string[] expectedMatches = { "GL01234567890", "GD02345678901" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.FolderMatches);
        }

        [TestMethod]
        public void Classifier_AsteriskDefinitn_ShouldMatchFolder()
        {
            //// arrange
            string[] expectedMatches = { "AX*3201", "AX0*123" };
            Classifier classifier = new Classifier(teststring);

            //// act

            //// assert
            CollectionAssert.IsSubsetOf(expectedMatches, classifier.FolderMatches);
        }
        #endregion
    }
}
