using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NethereumFaucet;
using System.Reflection.Metadata.Ecma335;


namespace NethereumFaucet
{
    [Route("api/faucet")]
    [ApiController]
    public class FaucetApiController : ControllerBase
    {
        
        public FaucetApiController(IFaucetService faucetService)
        {
            FaucetService = faucetService;
        }

        public IFaucetService FaucetService { get; }

        [HttpGet("canrequestfunds/{address}")]
        public async Task<ActionResult<bool>> CanRequestFundsAsync(string address)
        {
            try
            {
                return Ok( await FaucetService.CanRequestFundsAsync(address));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FaucetRequestResult>> RequestFunds([FromBody] string address)
        {
            try
            {
                return Ok(await FaucetService.ProvideFundsAsync(address));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
