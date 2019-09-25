using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RugerTek.AspNetCore.BancardVPOS.Configurations;
using RugerTek.AspNetCore.BancardVPOS.Constants;
using RugerTek.AspNetCore.BancardVPOS.Helpers;
using RugerTek.AspNetCore.BancardVPOS.HttpClients;
using RugerTek.AspNetCore.BancardVPOS.Interfaces;
using RugerTek.AspNetCore.BancardVPOS.Models;
using RugerTek.AspNetCore.BancardVPOS.Models.Api;

namespace RugerTek.AspNetCore.BancardVPOS.Services
{
    public class BancardVPosService : IBancardVPos
    {
        private readonly IVPosHttpClient _httpClient;
        private readonly BancardVPosConfiguration _configuration;
        
        public BancardVPosService(IServiceProvider serviceProvider, IOptions<BancardVPosConfiguration> options)
        {
            _httpClient = serviceProvider.GetRequiredService<IVPosHttpClient>();
            _configuration = options.Value;
        }
        
        public async Task<BancardResponse> SingleBuyAsync(BancardSingleBuyRequest request, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<SingleBuyOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new SingleBuyOperationApiModel
                {
                    Token = HashHelper.SingleBuy(_configuration.PublicKey, request.ShopProcessId, request.Amount, request.Currency.Value),
                    Currency = request.Currency.Value,
                    Amount = request.Amount.ToString("F2"),
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

        public async Task<BancardResponse> CardsNew(BancardCardsNewRequest request, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<CardsNewOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new CardsNewOperationApiModel
                {
                    Token = HashHelper.CardsNew(_configuration.PrivateKey, request.CardId, request.UserId),
                    CardId = request.CardId,
                    UserId = request.UserId,
                    ReturnUrl = request.ReturnUrl,
                    UserMail = request.UserMail,
                    UserCellPhone = request.UserCellPhone
                }
            };
            var response = await _httpClient.CardsNew(model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<ResponseApiModel>(cancellationToken);
            var returnModel = new BancardResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = responseBody.Status,
                ProcessId = responseBody.ProcessId
            };
            return returnModel;
        }

        public async Task<BancardUserCardsResponse> UsersCard(int userId, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<UsersCardsOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new UsersCardsOperationApiModel
                {
                    Token = HashHelper.UsersCards(_configuration.PrivateKey, userId)
                }
            };
            var respose = await _httpClient.UsersCards(userId, model, cancellationToken);
            var responseBody = await respose.Content.ReadAsAsync<UserCardsResponseApiModel>(cancellationToken);
            var returnModel = new BancardUserCardsResponse
            {
                IsSuccessStatusCode = respose.IsSuccessStatusCode,
                Status = responseBody.Status,
                Cards = responseBody.Cards.Select(x => new BancardCard
                {
                    AliasToken = x.AliasToken,
                    CardBrand = x.CardBrand,
                    CardId = x.CardId,
                    CardType = x.CardType,
                    ExpirationDate = x.ExpirationDate,
                    CardMaskedNumber = x.CardMaskedNumber
                }).ToList()
            };
            return returnModel;
        }

        public async Task<BancardSimpleResponse> Charge(BancardChargeRequest request, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<ChargeOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new ChargeOperationApiModel
                {
                    Token = HashHelper.Charge(_configuration.PrivateKey, request.ShopProcessId, request.Amount, request.Currency.Value, request.AliasToken),
                    Amount = request.Amount,
                    Currency = request.Currency.Value,
                    Description = request.Description,
                    AdditionalData = request.AdditionalData,
                    AliasToken = request.AliasToken,
                    NumberOfPayments = request.NumberOfPayments,
                    ShopProcessId = request.ShopProcessId
                }
            };
            var response = await _httpClient.Charge(model, cancellationToken);
            return new BancardSimpleResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = response.IsSuccessStatusCode ? "success" : "error"
            };
        }

        public async Task<BancardSimpleResponse> Delete(int userId, string aliasToken, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<DeleteOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new DeleteOperationApiModel
                {
                    Token = HashHelper.Delete(_configuration.PrivateKey, userId, aliasToken),
                    AliasToken = aliasToken
                }
            };
            var response = await _httpClient.DeleteCard(userId, model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<SimpleResponseApiModel>(cancellationToken);
            return new BancardSimpleResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = responseBody.Status
            };
        }

        public async Task<BancardMessageResponse> SingleBuyRollback(string shopProcessId, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<SingleBuyRollbackApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new SingleBuyRollbackApiModel
                {
                    Token = HashHelper.SingleBuyRollback(_configuration.PrivateKey, shopProcessId),
                    ShopProcessId = shopProcessId
                }
            };
            var response = await _httpClient.SingleBuyRollback(model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<MessageResponseApiModel>(cancellationToken);
            var returnModel = new BancardMessageResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = responseBody.Status,
                Messages = responseBody.Messages.Select(x => new BancardMessage
                {
                    Key = x?.Key ?? "",
                    Level = x?.Level ?? "",
                    Description = x?.Dsc ?? ""
                }).ToList()
            };
            return returnModel;
        }

        public async Task<BancardConfirmationResponse> GetSingleBuyConfirmation(string shopProcessId, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<SingleBuyConfirmationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new SingleBuyConfirmationApiModel
                {
                    Token = HashHelper.SingleBuyGetConfirmation(_configuration.PrivateKey, shopProcessId),
                    ShopProcessId = shopProcessId
                }
            };
            var response = await _httpClient.SingleBuyConfirm(model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<SingleBuyConfirmationResponseApiModel>(cancellationToken);
            var returnModel = new BancardConfirmationResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = responseBody?.Status ?? "error",
                Messages = responseBody?.Messages?.Select(x => new BancardMessage
                {
                    Key = x.Key,
                    Level = x.Level,
                    Description = x.Dsc
                }).ToList() ?? new List<BancardMessage>(),
                Confirmation = new BancardConfirmationInfo
                {
                    Token = responseBody?.Confirmation?.Token ?? "",
                    Amount = responseBody?.Confirmation?.Amount ?? 0,
                    Currency = BancardCurrency.Parse(responseBody?.Confirmation?.Currency ?? "PYG"),
                    Response = responseBody?.Confirmation?.Response ?? "",
                    AuthorizationNumber = responseBody?.Confirmation?.AuthorizationNumber ?? "",
                    ResponseCode = responseBody?.Confirmation?.ResponseCode ?? "",
                    ResponseDescription = responseBody?.Confirmation?.ResponseDescription ?? "",
                    ResponseDetails = responseBody?.Confirmation?.ResponseDetails ?? "",
                    ExtentedResponseDescription = responseBody?.Confirmation?.ExtentedResponseDescription ?? "",
                    ShopProcessId = responseBody?.Confirmation?.ShopProcessId ?? "",
                    SecurityInformation = new BancardSecurityInformation
                    {
                        Version = responseBody?.Confirmation?.SecurityInformation?.Version ?? "",
                        CardCountry = responseBody?.Confirmation?.SecurityInformation?.CardCountry ?? "",
                        CardSource = responseBody?.Confirmation?.SecurityInformation?.CardSource ?? "",
                        CustomerIp = responseBody?.Confirmation?.SecurityInformation?.CustomerIp ?? "",
                        RiskIndex = responseBody?.Confirmation?.SecurityInformation?.RiskIndex ?? ""
                    }
                }
            };

            return returnModel;
        }

        public Task<bool> ValidateSingleBuyConfirmToken(BancardSingleBuyConfirm request)
        {
            return Task.Run(() => 
                request.Operation.Token == HashHelper.SingleBuyConfirm(_configuration.PrivateKey, 
                    request.Operation.ShopProcessId, request.Operation.Amount, request.Operation.Currency));
        }
    }
}