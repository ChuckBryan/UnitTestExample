namespace RegisterUser.Tests
{
    #region Using Statements

    using System;
    using AutoMocking;
    using Shouldly;
    using Xunit;

    #endregion

    public class When_Email_Is_Invalid
    {
        [Fact]
        public void Then_argument_Null_exception_Will_Be_Thrown()
        {
            // Arrange
            var mocker = new MoqAutoMocker<AddNewUserService>();
            var addNewUserService = mocker.ClassUnderTest;


            // Act
            // Assert
            Should.Throw<ArgumentException>(
                () => { addNewUserService.AddUser("diver dan", "NotAnEmail", "P@ssword!"); });
        }
    }
}