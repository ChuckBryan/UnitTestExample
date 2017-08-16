namespace RegisterUser.Tests
{
    using System;
    using Moq;
    using Shouldly;

    public class When_Duplicate_Email_Exists
    {
        public void Then_Duplicate_Email_Error_Is_Thrown()
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