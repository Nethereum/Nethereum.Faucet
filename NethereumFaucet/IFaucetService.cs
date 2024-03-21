
namespace NethereumFaucet
{
    public interface IFaucetService
    {
        Task<bool> CanRequestFundsAsync(string address);
        Task<FaucetRequestResult> ProvideFundsAsync(string address);
    }
}