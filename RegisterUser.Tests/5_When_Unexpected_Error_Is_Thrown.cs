namespace RegisterUser.Tests
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Data;
    using Moq;
    using Shouldly;
    using StructureMap;
    using Xunit;

    #endregion

    public class When_Unexpected_Error_Is_Thrown : SpecFor<AddNewUserService>
    {
        public override void InitializeContainer(IContainer container)
        {
            var set = new Mock<DbSet<RegisteredUser>>().SetupData(new List<RegisteredUser>());
            var context = new Mock<RegisteredUserContext>();
            context.Setup(c => c.RegisteredUsers).Returns(set.Object);

            container.Configure(x => x.For<RegisteredUserContext>().Use(context.Object));

            base.InitializeContainer(container);
        }

        public override void Given()
        {
            GetMockFor<ISendValidationEmail>()
                .Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<Exception>();
            base.Given();
        }


        [Fact]
        public void Then_Registration_Will_Not_Be_Saved()
        {
            Should.Throw<Exception>(() => Sut.AddUser("Valid User", "valid@gmail.com", "****"));

            GetMockFor<RegisteredUserContext>().Verify(x => x.SaveChanges(), Times.Never);
        }


    }
}