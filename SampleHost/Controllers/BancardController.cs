using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RugerTek.AspNetCore.BancardVPOS.Constants;
using RugerTek.AspNetCore.BancardVPOS.Interfaces;
using RugerTek.AspNetCore.BancardVPOS.Models;

namespace SampleHost.Controllers
{
    public class BancardController : Controller
    {
        private readonly IBancardVPos _vPosService;

        public BancardController(IBancardVPos vPosService)
        {
            _vPosService = vPosService;
        }

        [HttpPost]
        public async Task<ActionResult<BancardResponse>> SingleBuy(CancellationToken cancellationToken)
        {
            var request = new BancardSingleBuyRequest
            {
                Amount = 100000,
                Currency = BancardCurrency.Guarani,
                ShopProcessId = "1",
                ReturnUrl = "http://localhost:5001/home",
                CancelUrl = "http://localhost:5001/error"
            };
            var response = await _vPosService.SingleBuyAsync(request, cancellationToken);
            return Ok(response);
        }
    }
}