using System;

namespace BddFixture.Example
{
    public class SomeClassWithDependencies
    {
        private readonly ISomeInterface _someInterface;
        private readonly ISomeOtherInterface _someOtherInterface;
        public bool IsInitialized;

        public SomeClassWithDependencies(ISomeInterface someInterface, ISomeOtherInterface someOtherInterface)
        {
            _someInterface = someInterface;
            _someOtherInterface = someOtherInterface;
        }

        public void DoSomething()
        {
            _someInterface.DoSomething(_someOtherInterface.SomeOperation());
        }

        public void Initialize()
        {
            if(IsInitialized)
                throw new InvalidOperationException();

            IsInitialized = true;
        }
    }
}