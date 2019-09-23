using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RugerTek.AspNetCore.BancardVPOS.Configurations;
using RugerTek.AspNetCore.BancardVPOS.Helpers;
using RugerTek.AspNetCore.BancardVPOS.HttpClients;
using RugerTek.AspNetCore.BancardVPOS.Interfaces;
using RugerTek.AspNetCore.BancardVPOS.Models;
using RugerTek.AspNetCore.BancardVPOS.Models.Api;

namespace RugerTek.AspNetCore.BancardVPOS.Services
{
    public class BancardVPosService : IBancardVPos
    {
        private readonly VPosHttpClient _httpClient;
        private readonly BancardVPosConfiguration _configuration;
        
        public BancardVPosService(VPosHttpClient httpClient, IOptions<BancardVPosConfiguration> options)
        {
            _httpClient = httpClient;
            _configuration = options.Value;
        }
        
        public async Task<BancardResponse> SingleBuyAsync(BancardSingleBuyRequest request, CancellationToken cancellationToken = default)
        {
            var model = new BancardRequestApiModel<SingleBuyOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new SingleBuyOperationApiModel
                {
                    Token = HashHelper.SingleBuy(_configuration.PublicKey, request.ShopProcessId, request.Amount, request.Currency.Value),
                    Currency = request.Currency.Value,
                    Amount = request.Amount.ToString("C2"),
                    ShopProcessId = request.ShopProcessId,
                    AdditionalData = request.AdditionalData,
                    ReturnUrl = request.ReturnUrl,
                    CancelUrl = request.CancelUrl
                }
            };
            var response = await _httpClient.SingleBuy(model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<ResponseApiModel>(cancellationToken);
            var returnModel = new BancardResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = responseBody.Status,
                ProcessId = responseBody.ProcessId
            };
            return returnModel;
        }

        public Task CardsNew()
        {
            throw new NotImplementedException();
        }

        public Task UsersCard()
        {
            throw new NotImplementedException();
        }

        public Task Charge()
        {
            throw new NotImplementedException();
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task SingleBuyRollback()
        {
            throw new NotImplementedException();
        }

        public Task GetSingleBuyConfirmation()
        {
            throw new NotImplementedException();
        }

        public Task SingleBuyConfirm()
        {
            throw new NotImplementedException();
        }
    }
}