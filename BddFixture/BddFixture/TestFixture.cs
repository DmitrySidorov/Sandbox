using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UnityAutoMoq;

namespace BddFixture
{
    public delegate void Given<TSut>(TSut sut, UnityAutoMoqContainer container);

    public abstract class TestFixture<TSut>
    {
        protected UnityAutoMoqContainer Container;
        protected TSut Sut;

        private Exception _caught;
        private bool _caughtAccessed;
        protected Exception Caught
        {
            get
            {
                _caughtAccessed = true;
                return _caught;
            }
        }

        protected abstract IEnumerable<Given<TSut>> Given();
        protected abstract void When();

        [SetUp]
        public void Setup()
        {
            _caught = null;
            _caughtAccessed = false;

            Container = CreateContainer();
            Sut = Container.Resolve<TSut>();

            foreach (var given in Given())
                given(Sut, Container);

            try
            {
                When();
            }
            catch (Exception e)
            {
                _caught = e;
            }
        }

        [TearDown]
        public void TearDown()
        {
            After();
            if (_caught != null && !_caughtAccessed)
                throw new Exception("An unhandled exception was thrown during this test. Please check the inner exception for more details.", _caught);
        }

        protected virtual void After() { }

        protected Mock<T> GetMock<T>() where T : class
        {
            return Container.GetMock<T>();
        }

        protected virtual UnityAutoMoqContainer CreateContainer()
        {
            return new UnityAutoMoqContainer();
        }

    }
}