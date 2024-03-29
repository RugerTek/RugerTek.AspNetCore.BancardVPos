using System;
using System.Collections.Generic;
using System.Linq;
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
                    Token = HashHelper.SingleBuy(_configuration.PrivateKey, request.ShopProcessId, request.Amount, request.Currency.Value),
                    Currency = request.Currency.Value,
                    Amount = request.Amount.ToString("F2"),
                    ShopProcessId = request.ShopProcessId,
                    AdditionalData = request.AdditionalData,
                    ReturnUrl = request.ReturnUrl,
                    CancelUrl = request.CancelUrl,
                    Description = request.Description
                }
            };
            var response = await _httpClient.SingleBuy(model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<ResponseApiModel>(cancellationToken);

            if (responseBody is null)
            {
                return new BancardResponse
                {
                    IsSuccessStatusCode = false,
                    Messages = new List<BancardMessage>(),
                    ProcessId = null,
                    Status = "null body"
                };
            }
            
            return MapResponse(responseBody, response.IsSuccessStatusCode);
        }
        
        public async Task<BancardResponse> ZimpleSingleBuyAsync(BancardZimpleSingleBuyRequest request, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<ZimpleSingleBuyOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new ZimpleSingleBuyOperationApiModel
                {
                    Token = HashHelper.SingleBuy(_configuration.PrivateKey, request.ShopProcessId, request.Amount, request.Currency.Value),
                    Currency = request.Currency.Value,
                    Amount = request.Amount.ToString("F2"),
                    ShopProcessId = request.ShopProcessId,
                    AdditionalData = request.AdditionalData,
                    ReturnUrl = request.ReturnUrl,
                    CancelUrl = request.CancelUrl,
                    Description = request.Description,
                    Zimple = "S"
                }
            };
            
            var response = await _httpClient.ZimpleSingleBuy(model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<ResponseApiModel>(cancellationToken);
                
            if (responseBody is null)
            {
                return new BancardResponse
                {
                    IsSuccessStatusCode = false,
                    Messages = new List<BancardMessage>(),
                    ProcessId = null,
                    Status = "null body"
                };
            }
                
            return MapResponse(responseBody, response.IsSuccessStatusCode);
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
            
            if (responseBody is null)
            {
                return new BancardResponse
                {
                    IsSuccessStatusCode = false,
                    Messages = new List<BancardMessage>(),
                    ProcessId = null,
                    Status = "null body"
                };
            }
            
            return MapResponse(responseBody, response.IsSuccessStatusCode);
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
            var response = await _httpClient.UsersCards(userId, model, cancellationToken);
            var responseBody = await response.Content.ReadAsAsync<UserCardsResponseApiModel>(cancellationToken);
            
            if (responseBody is null)
            {
                return new BancardUserCardsResponse
                {
                    IsSuccessStatusCode = false,
                    Messages = new List<BancardMessage>(),
                    ProcessId = null,
                    Status = "null body",
                    Cards = new List<BancardCard>()
                };
            }
            
            var returnModel = new BancardUserCardsResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = responseBody.Status,
                Cards = responseBody.Cards.Select(x => new BancardCard
                {
                    AliasToken = x.AliasToken,
                    CardBrand = x.CardBrand,
                    CardId = x.CardId,
                    CardType = x.CardType,
                    ExpirationDate = x.ExpirationDate,
                    CardMaskedNumber = x.CardMaskedNumber
                }).ToList(),
                Messages = responseBody.Messages.Select(x => new BancardMessage
                {
                    Key = x.Key,
                    Level = x.Level,
                    Description = x.Dsc
                }).ToList()
            };
            return returnModel;
        }

        public async Task<BancardChargeResponse?> Charge(BancardChargeRequest request, CancellationToken cancellationToken = default)
        {
            var model = new RequestApiModel<ChargeOperationApiModel>
            {
                PublicKey = _configuration.PublicKey,
                Operation = new ChargeOperationApiModel
                {
                    Token = HashHelper.Charge(_configuration.PrivateKey, request.ShopProcessId, request.Amount, request.Currency.Value, request.AliasToken),
                    Amount = request.Amount.ToString("F2"),
                    Currency = request.Currency.Value,
                    Description = request.Description,
                    AdditionalData = request.AdditionalData,
                    AliasToken = request.AliasToken,
                    NumberOfPayments = request.NumberOfPayments,
                    ShopProcessId = request.ShopProcessId
                }
            };
            var response = await _httpClient.Charge(model, cancellationToken);
            
            if (!response.IsSuccessStatusCode)
            {
                var responseModel = await response.Content.ReadAsAsync<ResponseApiModel>(cancellationToken);
                if (responseModel is null)
                {
                    return new BancardChargeResponse
                    {
                        IsSuccessful = false,
                    };
                }
                var stuff = MapResponse(responseModel, response.IsSuccessStatusCode);
                return new BancardChargeResponse
                {
                    IsSuccessful = response.IsSuccessStatusCode,
                    BancardResponse = stuff
                };
            }
            var responseBody = await response.Content.ReadAsAsync<ChargeResponseApiModel>(cancellationToken);
            if (responseBody is null)
            {
                return new BancardChargeResponse
                {
                    IsSuccessful = true,
                };
            }
            
            var chargeResponse = new BancardChargeResponse
            {
                IsSuccessful = true,
                Amount = responseBody.Confirmation.Amount,
                Currency = responseBody.Confirmation.Currency,
                Response = responseBody.Confirmation.Response,
                Token = responseBody.Confirmation.Token,
                AuthorizationNumber = responseBody.Confirmation.AuthorizationNumber,
                ResponseCode = responseBody.Confirmation.ResponseCode,
                ResponseDescription = responseBody.Confirmation.ResponseDescription,
                ResponseDetails = responseBody.Confirmation.ResponseDetails,
                SecurityInformation = new BancardSecurityInformation
                {
                    Version = responseBody.Confirmation.SecurityInformation.Version,
                    CardCountry = responseBody.Confirmation.SecurityInformation.CardCountry,
                    CardSource = responseBody.Confirmation.SecurityInformation.CardSource,
                    CustomerIp = responseBody.Confirmation.SecurityInformation.CustomerIp,
                    RiskIndex = responseBody.Confirmation.SecurityInformation.RiskIndex,
                },
                TicketNumber = responseBody.Confirmation.TicketNumber,
                ExtendedResponseDescription = responseBody.Confirmation.ExtendedResponseDescription,
                ShopProcessId = responseBody.Confirmation.ShopProcessId
            };
            return chargeResponse;
        }

        public async Task<BancardResponse> Delete(int userId, string aliasToken, CancellationToken cancellationToken = default)
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
            var responseBody = await response.Content.ReadAsAsync<ResponseApiModel>(cancellationToken);
            
            if (responseBody is null)
            {
                return new BancardResponse
                {
                    IsSuccessStatusCode = false,
                    Messages = new List<BancardMessage>(),
                    ProcessId = null,
                    Status = "null body"
                };
            }
            
            return MapResponse(responseBody, response.IsSuccessStatusCode);
        }

        public async Task<BancardResponse> SingleBuyRollback(int shopProcessId, CancellationToken cancellationToken = default)
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
            var responseBody = await response.Content.ReadAsAsync<ResponseApiModel>(cancellationToken);
            
            if (responseBody is null)
            {
                return new BancardResponse
                {
                    IsSuccessStatusCode = false,
                    Messages = new List<BancardMessage>(),
                    ProcessId = null,
                    Status = "null body"
                };
            }
            
            return MapResponse(responseBody, response.IsSuccessStatusCode);
        }

        public async Task<BancardConfirmationResponse> GetSingleBuyConfirmation(int shopProcessId, CancellationToken cancellationToken = default)
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
            
            if (responseBody is null)
            {
                return new BancardConfirmationResponse
                {
                    IsSuccessStatusCode = false,
                    Messages = new List<BancardMessage>(),
                    ProcessId = null,
                    Status = "null body"
                };
            }
            
            var returnModel = new BancardConfirmationResponse
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Status = responseBody.Status,
                Messages = responseBody.Messages.Select(x => new BancardMessage
                {
                    Key = x.Key,
                    Level = x.Level,
                    Description = x.Dsc
                }).ToList(),
                Confirmation = new BancardConfirmationInfo
                {
                    Token = responseBody.Confirmation.Token,
                    Amount = responseBody.Confirmation.Amount,
                    Currency = BancardCurrency.Parse(responseBody.Confirmation.Currency),
                    Response = responseBody.Confirmation.Response,
                    AuthorizationNumber = responseBody.Confirmation.AuthorizationNumber,
                    ResponseCode = responseBody.Confirmation.ResponseCode,
                    ResponseDescription = responseBody.Confirmation.ResponseDescription,
                    ResponseDetails = responseBody.Confirmation.ResponseDetails,
                    ExtentedResponseDescription = responseBody.Confirmation.ExtentedResponseDescription,
                    ShopProcessId = responseBody.Confirmation.ShopProcessId,
                    SecurityInformation = new BancardSecurityInformation
                    {
                        Version = responseBody.Confirmation.SecurityInformation.Version,
                        CardCountry = responseBody.Confirmation.SecurityInformation.CardCountry,
                        CardSource = responseBody.Confirmation.SecurityInformation.CardSource,
                        CustomerIp = responseBody.Confirmation.SecurityInformation.CustomerIp,
                        RiskIndex = int.TryParse(responseBody.Confirmation.SecurityInformation.RiskIndex, out var riskIndex) ? riskIndex : 0,
                    }
                }
            };

            return returnModel;
        }

        public Task<bool> ValidateSingleBuyConfirmToken(BancardSingleBuyConfirm request)
        {
            return Task.Run(() => 
                request.Operation.Token == HashHelper.SingleBuyConfirm(_configuration.PrivateKey, 
                    request.Operation.ShopProcessId, request.Operation.Amount ?? "0", request.Operation.Currency ?? "PYG"));
        }

        private static BancardResponse MapResponse(ResponseApiModel apiModel, bool isSuccessStatusCode)
        {
            var model = new BancardResponse
            {
                IsSuccessStatusCode = isSuccessStatusCode,
                Status = apiModel.Status,
                Messages = apiModel.Messages.Select(x => new BancardMessage
                {
                    Key = x.Key,
                    Level = x.Level,
                    Description = x.Dsc
                }).ToList(),
                ProcessId = apiModel.ProcessId
            };
            return model;
        }
    }
}