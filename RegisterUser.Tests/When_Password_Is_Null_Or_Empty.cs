namespace RegisterUser.Tests
{
    using System;
    using Moq;
    using Shouldly;
    using Xunit;

    public class When_Password_Is_Null_Or_Empty
    {
        [Fact]
        public void Then_Argument_Null_Exception_Is_Thrown()
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
                addNewUserService.AddUser(null, "test@test.com", "");
            });
        }
    }
}