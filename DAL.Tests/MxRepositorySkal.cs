using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL.Tests
{
    [TestClass]
    public class MxRepositorySkal
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void GetMxRecordsSkalReturnereDataForDgiDk()
        {
            // Assert
            var target = new MxRepository();

            // Act
            var result = target.GetMxRecords("dgi.dk");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GetMxRecordsSkalReturnereDataForIkkeeksisterendeDomaene()
        {
            // Assert
            var target = new MxRepository();

            // Act
            var result = target.GetMxRecords("falskfalskfalsk.dk");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}