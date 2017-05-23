using System;
using Dgi.Email.ApplicationService.Services;
using Dgi.Email.Dal.Repositories;
using Dgi.Email.Delt.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Dgi.Email.Test.Services
{
    public class EmailServiceSkal
    {
        
        [Fact]
        public void ReturnereAtEmailadresseMedMxDomaeneFindes()
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
        public void ReturnereAtEmailadresseUdenMxDomaeneIkkeFindes()
        {
            // Arrange
            string emailadresse = "jacob.kamp.lund@dgi" + Guid.NewGuid().ToString().Replace("-", "") + ".dk";
            var emailService = new EmailService(new EmailRepository());

            // Act
            var result = emailService.Verify(emailadresse);

            // Assert
            Assert.False(result);
        }
    }
}