using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Application.Tests
{
    [TestClass]
    public class MappingProfileTest
    {
        [TestMethod]
        public void MappingProfile_IsValid()
        {
            // Arrange
            var profile = new MapperConfiguration(x => x.AddProfile<MappingProfile>());

            // Act
            // Assert
            profile.AssertConfigurationIsValid();
        }
    }
}
