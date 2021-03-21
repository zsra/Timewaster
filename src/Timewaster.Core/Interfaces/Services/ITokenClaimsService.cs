using System.Threading.Tasks;

namespace Timewaster.Core.Interfaces.Services
{
    public interface ITokenClaimsService
    {
        ValueTask<string> GetTokenAsync(string userName);
    }
}
