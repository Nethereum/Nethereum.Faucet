using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NethereumFaucet.ViewModel
{
    public class FaucetViewModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Addresses should be 40 characters in length", MinimumLength = 40)]
        public string Address { get; set; }

        public string TransactionHash { get; set; }

        public int Amount { get; set; }
    }
}
