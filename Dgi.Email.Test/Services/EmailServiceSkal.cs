using System;
using Dgi.Email.ApplicationService.Services;
using Dgi.Email.Dal.Repositories;
using Xunit;

namespace Dgi.Email.Test.Services
{
    public class EmailServiceSkal
    {

        [Fact]
        public void IkkeGodkendeEmailadresse_NaarEmailadresseManglerDomaene()
        {
            // Arrange
            string emailadresse = "jacob.kamp.lund dgi.dk";
            var emailService = new EmailService(new EmailRepository());

            // Act
            var result = emailService.Verify(emailadresse);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GodkendeEmailadresse_NaarEmailadresseHarKendtDomaene()
        {
            // Arrange
            string emailadresse = "jacob.kamp.lund@dgi.dk";
            var emailService = new EmailService(new EmailRepository());

            // Act
            var result = emailService.Verify(emailadresse);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GodkendeEmailadresse_NaarEmailadresseHarFlereDomaenedeleOgEnderMedKendtDomaene()
        {
            // Arrange
            string emailadresse = "jacob.kamp.lund@abc.dk@dgi.dk";
            var emailService = new EmailService(new EmailRepository());

            // Act
            var result = emailService.Verify(emailadresse);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IkkeGodkendeEmailadresse_NaarEmailadresseErUdenKendtDomaene()
        {
            // Arrange
            string emailadresse = "jacob.kamp.lund@dgi" + Guid.NewGuid().ToString().Replace("-", "") + ".dk";
            var emailService = new EmailService(new EmailRepository());

            // Act
            var result = emailService.Verify(emailadresse);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IkkeGodkendeEmailadresse_NaarEmailadresseHarFlereDomaenedeleOgEnderMedUkendtDomaene()
        {
            // Arrange
            string emailadresse = "jacob.kamp.lund@dgi.dk@" + Guid.NewGuid().ToString().Replace("-", "") + ".dk";
            var emailService = new EmailService(new EmailRepository());

            // Act
            var result = emailService.Verify(emailadresse);

            // Assert
            Assert.False(result);
        }


    }
}