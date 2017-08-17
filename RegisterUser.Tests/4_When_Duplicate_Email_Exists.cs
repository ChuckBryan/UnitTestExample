namespace RegisterUser.Tests
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Data.Entity;
    using AutoMocking;
    using Data;
    using Moq;
    using Shouldly;
    using Xunit;

    #endregion

    public class When_Duplicate_Email_Exists
    {
        [Fact]
        public void Then_Duplicate_Email_Error_Is_Thrown()
        {
            // Arrange
            var data = new List<RegisteredUser>
            {
                RegisteredUser.Create("Leia Organa",  "lorgana@gmail.com",  "********")
            };

            var set = new Mock<DbSet<RegisteredUser>>().SetupData(data);
            var context = new Mock<RegisteredUserContext>();
            context.Setup(c => c.RegisteredUsers).Returns(set.Object);

            var mocker = new MoqAutoMocker<AddNewUserService>();
            mocker.Inject(context.Object);

            var addNewUserService = mocker.ClassUnderTest;

            // Act
            // Assert

            Should.Throw<DuplicateEmailError>(() =>
            {
                addNewUserService.AddUser("Obi Wan Kenobi", "lorgana@gmail.com", "P@ssword!");
            });
        }
    }
}