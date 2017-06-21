using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NethereumFaucet
{
    public class FaucetSettings
    {
        public string EthereumAddress { get; set; }
        public string FunderPrivateKey { get; set; }
        public int MaxAmountToFund { get; set; }
        public int AmountToFund { get; set; }
        public string UrlTxnExplorer { get; set; }
    }
}
