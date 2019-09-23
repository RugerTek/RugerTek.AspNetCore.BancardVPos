using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RugerTek.AspNetCore.BancardVPOS.Models.Api;

namespace RugerTek.AspNetCore.BancardVPOS.HttpClients
{
    public class VPosHttpClient
    {
        private readonly HttpClient _httpClient;

        public VPosHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SingleBuy(BancardRequestApiModel<SingleBuyOperationApiModel> body, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> CardsNew(BancardRequestApiModel<CardsNewOperationApiModel> body, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/cards/new")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> UsersCards(int userId, BancardRequestApiModel<UsersCardsOperationApiModel> body, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"/vpos/api/0.3/users/{userId}/cards")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> Charge(BancardRequestApiModel<ChargeOperationApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/charge")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteCard(string userId, BancardRequestApiModel<DeleteOperationApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/vpos/api/0.3/users/{userId}/cards")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> SingleBuyRollback(BancardRequestApiModel<SingleBuyRollbackApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy/rollback")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }
        
        public Task<HttpResponseMessage> SingleBuyConfirm(BancardRequestApiModel<SingleBuyConfirmationApiModel> body,
            CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy/confirmations")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }
    }
}