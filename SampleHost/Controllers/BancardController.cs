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
        public async Task<ActionResult<BancardResponse>> SingleBuy([FromQuery] string shopProcessId, CancellationToken cancellationToken)
        {
            var request = new BancardSingleBuyRequest
            {
                Description = "Matricula 2019",
                Amount = 100000,
                Currency = BancardCurrency.Guarani,
                ShopProcessId = shopProcessId,
                ReturnUrl = "https://localhost:5001/home",
                CancelUrl = "https://localhost:5001/error"
            };
            var response = await _vPosService.SingleBuyAsync(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BancardResponse>> CardsNew(CancellationToken cancellationToken)
        {
            var request = new BancardCardsNewRequest
            {
                CardId = 1,
                ReturnUrl = "https://localhost:5001/home",
                UserId = 909,
                UserMail = "contacto@rugertek.com",
                UserCellPhone = "+595981123456"
            };

            var response = await _vPosService.CardsNew(request, cancellationToken);
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<BancardResponse>> UsersCard(CancellationToken cancellationToken)
        {
            var response = await _vPosService.UsersCard(1, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BancardResponse>> Charge(CancellationToken cancellationToken)
        {
            var request = new BancardChargeRequest
            {
                Amount = 100000,
                Currency = BancardCurrency.Guarani,
                Description = "Prueba de cobro con token",
                AdditionalData = "",
                AliasToken = "226ad43de1e686ae554f886308b949bba9ac798a7d7da48f1548ccc9050f101f",
                NumberOfPayments = 1,
                ShopProcessId = "52"
            };
            var response = await _vPosService.Charge(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<BancardResponse>> Delete(CancellationToken cancellationToken)
        {
            var response = await _vPosService.Delete(1, "226ad43de1e686ae554f886308b949bba9ac798a7d7da48f1548ccc9050f101f", cancellationToken);
            return Ok(response);
        }
    }
}