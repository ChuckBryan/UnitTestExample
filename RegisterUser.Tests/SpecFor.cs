namespace RegisterUser.Tests
{
    using AutoMocking;
    using Moq;
    using StructureMap;

    public abstract class SpecFor<TSut> where TSut : class
    {
        public MoqAutoMocker<TSut> Mocker { get; private set; }

        protected SpecFor()
        {
            Mocker = new MoqAutoMocker<TSut>();

            Configure();
        }

        public TSut Sut => Mocker.ClassUnderTest;

        private void Configure()
        {
            InitializeContainer(Mocker.Container);

            Given();

            When();
        }

        public virtual void InitializeContainer(IContainer container)
        {
            
        }

        public virtual void Given()
        {
            
        }

        public virtual void When()
        {
            
        }

        public Mock<TMock> GetMockFor<TMock>() where TMock : class
        {
            return Mocker.GetMockFor<TMock>();
        }
    }
}