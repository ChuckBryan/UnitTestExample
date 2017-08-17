namespace RegisterUser.Tests
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Moq;
    using Shouldly;
    using StructureMap;
    using Xunit;

    #endregion

    public class When_Add_New_User_Service_Saves : SpecFor<AddNewUserService>
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
            Sut.AddUser("Valid User", "valid@gmail.com", "****");
        }

        [Fact]
        public void Then_Registration_Will_Be_Saved()
        {
            GetMockFor<RegisteredUserContext>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Then_There_Should_Be_One_Record()
        {
            GetMockFor<RegisteredUserContext>().Object.RegisteredUsers.Count().ShouldBe(1);
        }
    }
}