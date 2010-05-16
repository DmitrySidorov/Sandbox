using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BddFixture.Example
{
    public partial class SomeClassWithDependenciesFixture
    {
        [TestFixture]
        public class When_initializing_some_class : TestFixture<SomeClassWithDependencies>
        {
            protected override IEnumerable<Given<SomeClassWithDependencies>> Given()
            {
                yield return given.nothing;
            }

            protected override void When()
            {
                Sut.Initialize();
            }

            [Test]
            public void class_is_initialized()
            {
                Sut.IsInitialized.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_initializing_some_class_already_initialized : TestFixture<SomeClassWithDependencies>
        {
            protected override IEnumerable<Given<SomeClassWithDependencies>> Given()
            {
                yield return given.class_is_initialized;
            }

            protected override void When()
            {
                Sut.Initialize();
            }

            [Test]
            public void throws_exception()
            {
                Caught.ShouldBeOfType<InvalidOperationException>();
            }
        }

        [TestFixture]
        public class When_doing_something : TestFixture<SomeClassWithDependencies>
        {
            protected override IEnumerable<Given<SomeClassWithDependencies>> Given()
            {
                yield return given.class_is_initialized;
                yield return given.some_operation_returns_1;
            }

            protected override void When()
            {
                Sut.DoSomething();
            }

            [Test]
            public void should_do_something_on_dependency()
            {
                GetMock<ISomeInterface>().Verify(x => x.DoSomething(1));
            }
        }
    }
}