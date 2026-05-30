using BeyondNetCode.Shell.Bootstrapper.Interface;

namespace BeyondNetCode.Shell.Bootstrapper.Tests.Impl
{
    public class DoSomethingBootstrapper : IBootstrapper<bool>
    {
        public void Run()
        {
            Result = true;
        }

        public bool Result { get; private set; }
    }
}
