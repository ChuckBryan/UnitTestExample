namespace RegisterUser.Tests
{
    using System;
    using Moq;
    using Shouldly;
    using Xunit;

    public class When_DisplayName_Is_Null
    {
        [Fact]
        public void Then_Argument_Null_Exception_Will_Be_Thrown()
        {
            // Arrange
            var mockDbContext = new Mock<RegisteredUserContext>();
            var mockSendValidationEmail = new Mock<ISendValidationEmail>();
            var mockLogger = new Mock<ILogger>();

            var addNewUserService =
                new AddNewUserService(mockDbContext.Object, mockSendValidationEmail.Object, mockLogger.Object);

            // Act
            // Assert

            Should.Throw<ArgumentNullException>(() =>
            {
                addNewUserService.AddUser(null, "test@test.com", "P@ssword!");
            });
        }
    }
}