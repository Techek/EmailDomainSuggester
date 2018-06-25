using DAL;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Tests
{
    [TestClass]
    public class MxServiceSkal
    {
        [TestMethod]
        public void ReturnereFalseNaarIngenMxRecordsReturneres()
        {
            // Arrange
            string nslookup = null;

            var fakeMxRepo = A.Fake<IMxRepository>();
            A.CallTo(() => fakeMxRepo.GetMxRecords(A<string>.Ignored)).Returns(null);

            var target = new MxService(fakeMxRepo);

            // Act
            var actual = target.HasMxRecord("ligegyldig");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ReturnereFalskNaarDomaeneIkkeHarEnMxRecord()
        {
            // Arrange
            var nslookup = @"
Server:  ad01.dgi.ds
Address:  192.168.1.121

*** ad01.dgi.ds can't find falskfalskfalsk.dk: Non-existent domain
";

            var fakeMxRepo = A.Fake<IMxRepository>();
            A.CallTo(() => fakeMxRepo.GetMxRecords(A<string>.Ignored)).Returns(nslookup);

            var target = new MxService(fakeMxRepo);

            // Act
            var actual = target.HasMxRecord("ligegyldig");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ReturnereTrueNaarDomaeneHarEnMxRecord()
        {
            // Arrange
            var nslookup = @"
Server:  ad01.dgi.ds
Address:  192.168.1.121

dgi.dk  MX preference = 0, mail exchanger = mail.dgi.dk
mail.dgi.dk     internet address = 172.16.0.68
";

            var fakeMxRepo = A.Fake<IMxRepository>();
            A.CallTo(() => fakeMxRepo.GetMxRecords(A<string>.Ignored)).Returns(nslookup);

            var target = new MxService(fakeMxRepo);

            // Act
            var actual = target.HasMxRecord("ligegyldig");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReturnereTrueNaarDomaeneHarFlereMxRecords()
        {
            // Arrange
            var nslookup = @"
Server:  ad01.dgi.ds
Address:  192.168.1.121

dgi.dk  MX preference = 20, mail exchanger = mail1.dgi.dk
dgi.dk  MX preference = 30, mail exchanger = mail2.dgi.dk
dgi.dk  MX preference = 10, mail exchanger = mail3.dgi.dk
mail.dgi.dk     internet address = 172.16.0.68
";
            
            var fakeMxRepo = A.Fake<IMxRepository>();
            A.CallTo(() => fakeMxRepo.GetMxRecords(A<string>.Ignored)).Returns(nslookup);

            var target = new MxService(fakeMxRepo);

            // Act
            var actual = target.HasMxRecord("ligegyldig");

            // Assert
            Assert.IsTrue(actual);
        }
    }
}