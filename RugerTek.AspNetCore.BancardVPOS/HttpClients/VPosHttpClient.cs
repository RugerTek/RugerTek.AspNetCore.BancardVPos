using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using RugerTek.AspNetCore.BancardVPOS.Models.Api;

namespace RugerTek.AspNetCore.BancardVPOS.HttpClients
{
    internal class VPosHttpClient : IVPosHttpClient
    {
        private readonly HttpClient _httpClient;

        public VPosHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SingleBuy(RequestApiModel<SingleBuyOperationApiModel> body, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }
        
        public Task<HttpResponseMessage> ZimpleSingleBuy(RequestApiModel<ZimpleSingleBuyOperationApiModel> body, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> CardsNew(RequestApiModel<CardsNewOperationApiModel> body, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/cards/new")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> UsersCards(int userId, RequestApiModel<UsersCardsOperationApiModel> body, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"/vpos/api/0.3/users/{userId}/cards")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> Charge(RequestApiModel<ChargeOperationApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/charge")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteCard(int userId, RequestApiModel<DeleteOperationApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/vpos/api/0.3/users/{userId}/cards")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> SingleBuyRollback(RequestApiModel<SingleBuyRollbackApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy/rollback")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }
        
        public Task<HttpResponseMessage> SingleBuyConfirm(RequestApiModel<SingleBuyConfirmationApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy/confirmations")
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }
    }
}