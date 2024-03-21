using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NethereumFaucet
{
    public class FaucetSettings
    {
        public string RpcAddress { get; set; }
        public string ChainName { get; set; }
        public string FunderPrivateKey { get; set; }
        public decimal MaxAmountToFund { get; set; }
        public decimal AmountToFund { get; set; }
        public int? ChainGasSendTransaction { get; set; }
        public string CurrencySymbol { get; set; }  
        public string UrlTxnExplorer { get; set; }
    }
}
