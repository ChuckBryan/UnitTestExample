namespace RegisterUser.Tests
{
    using System;
    using Automocking.SpecsFor.AutoMocking;
    using Moq;
    using Shouldly;
    using Xunit;

    public class When_Email_Is_Invalid
    {
        [Fact]
        public void Then_argument_Null_exception_Will_Be_Thrown()
        {
            // Arrange
            var mocker = new MoqAutoMocker<AddNewUserService>();
            //var mockDbContext = new Mock<RegisteredUserContext>();
            //var mockSendValidationEmail = new Mock<ISendValidationEmail>();
            //var mockLogger = new Mock<ILogger>();

            var addNewUserService = mocker.ClassUnderTest;
                

            // Act
            // Assert
            Should.Throw<ArgumentException>(() =>
            {
                addNewUserService.AddUser("diver dan", "NotAnEmail", "P@ssword!");
            });
        }
    }
}