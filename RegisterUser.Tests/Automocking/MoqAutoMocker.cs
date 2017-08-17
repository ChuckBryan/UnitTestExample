namespace RegisterUser.Tests.AutoMocking
{
    using StructureMap.AutoMocking;

    using Moq;

    public class MoqAutoMocker<T> : AutoMocker<T> where T : class
    {
        public MoqAutoMocker() : base(new MoqServiceLocator())
        {
            ServiceLocator = new MoqServiceLocator();
        }

        public Mock<TMock> GetMockFor<TMock>() where TMock : class
        {
            return Mock.Get(Get<TMock>());
        }
    }
}