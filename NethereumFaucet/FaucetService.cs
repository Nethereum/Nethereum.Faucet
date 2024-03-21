using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nethereum.ABI.CompilationMetadata;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace NethereumFaucet
{
    public class FaucetService : IFaucetService
    {
        FaucetSettings settings;

        public FaucetService(IOptions<FaucetSettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<FaucetRequestResult> ProvideFundsAsync(string address)
        {
            if (address.IsValidEthereumAddressHexFormat() == false)
            {
                throw new ArgumentException("Invalid Ethereum address");
            }
            var account = new Account(settings.FunderPrivateKey);
            var web3 = new Web3(account, settings.RpcAddress);

            var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
            if (Nethereum.Web3.Web3.Convert.FromWei(balance.Value) >= settings.MaxAmountToFund)
            {
                throw new Exception(address + " already has more than " + settings.MaxAmountToFund + " " + settings.CurrencySymbol);
            }
            var amountToFund = Web3.Convert.ToWei(settings.AmountToFund) - balance; // just enable top up to the amount to fund
            var gas = settings.ChainGasSendTransaction ?? 21000;
            var txnInput = new TransactionInput()
            {
                Gas = new HexBigInteger(gas),
                Value = new HexBigInteger(amountToFund),
                To = address,
                From = account.Address
            };
            var txnHash = await web3.Eth.TransactionManager.SendTransactionAsync(txnInput);
            //we are going to wait for the transaction to be mined so we can avoid the user to double click whilst the transaction is being mined
            // a better solution will be to have a database and a background service to check the transaction status and update the database, disabling the user to request more funds
            var txnReceipt = await web3.TransactionReceiptPolling.PollForReceiptAsync(txnHash, new CancellationTokenSource(TimeSpan.FromMinutes(1)).Token);
            return new FaucetRequestResult
            {
                TransactionHash = txnHash,
                Amount = Web3.Convert.FromWei(amountToFund)
            };
        }

        public async Task<bool> CanRequestFundsAsync(string address)
        {
            if (address.IsValidEthereumAddressHexFormat() == false)
            {
                throw new ArgumentException("Invalid Ethereum address");
            }
            var web3 = new Web3(settings.RpcAddress);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
            return Nethereum.Web3.Web3.Convert.FromWei(balance.Value) < settings.MaxAmountToFund;

        }
    }

    public class FaucetRequestResult
    {
        public string TransactionHash { get; set; }
        public decimal Amount { get; set; }
    }
}
