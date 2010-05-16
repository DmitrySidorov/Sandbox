using UnityAutoMoq;

namespace BddFixture.Example
{
    public partial class SomeClassWithDependenciesFixture
    {
        public class given
        {
            public static void some_operation_returns_1(SomeClassWithDependencies sut, UnityAutoMoqContainer container)
            {
                container.GetMock<ISomeOtherInterface>().Setup(x => x.SomeOperation()).Returns(1);
            }

            public static void class_is_initialized(SomeClassWithDependencies sut, UnityAutoMoqContainer container)
            {
                sut.Initialize();
            }

            public static void nothing(SomeClassWithDependencies sut, UnityAutoMoqContainer container)
            {
            }
        }
    }
}