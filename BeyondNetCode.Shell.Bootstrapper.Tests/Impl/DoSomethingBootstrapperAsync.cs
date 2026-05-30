using System.Threading;
using System.Threading.Tasks;
using BeyondNetCode.Shell.Bootstrapper.Interface;

namespace BeyondNetCode.Shell.Bootstrapper.Tests.Impl
{
    public class DoSomethingBootstrapperAsync : IBootstrapperAsync<bool>
    {
        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(10, cancellationToken);
            Result = true;
        }

        public bool Result { get; private set; }
    }
}
