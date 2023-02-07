using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RugerTek.AspNetCore.BancardVPOS.Constants;
using RugerTek.AspNetCore.BancardVPOS.Interfaces;
using RugerTek.AspNetCore.BancardVPOS.Models;

namespace SampleHost.Controllers
{
    [ApiController, Route("/api/[controller]")]
    public class BancardController : ControllerBase
    {
        private readonly IBancardVPos _vPosService;

        public BancardController(IBancardVPos vPosService)
        {
            _vPosService = vPosService;
        }

        [HttpPost("confirmation/{id:int}")]
        public async Task<ActionResult<BancardResponse>> GetConfirmation(int id, CancellationToken cancellationToken)
        {
            var response = await _vPosService.GetSingleBuyConfirmation(id, cancellationToken);
            return Ok(response);
        }
        
        [HttpPost("single-buy/{shopProcessId:int}")]
        public async Task<ActionResult<BancardResponse>> SingleBuy(int shopProcessId, CancellationToken cancellationToken)
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

        [HttpPost("cards-new")]
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
        
        [HttpPost("users-card")]
        public async Task<ActionResult<BancardResponse>> UsersCard(CancellationToken cancellationToken)
        {
            var response = await _vPosService.UsersCard(1, cancellationToken);
            return Ok(response);
        }

        [HttpPost("charge")]
        public async Task<ActionResult<BancardResponse>> Charge(CancellationToken cancellationToken)
        {
            var request = new BancardChargeRequest
            {
                Amount = 100000,
                Currency = BancardCurrency.Guarani,
                Description = "Prueba de cobro con token",
                AdditionalData = "",
                AliasToken = "",
                NumberOfPayments = 1,
                ShopProcessId = 194
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