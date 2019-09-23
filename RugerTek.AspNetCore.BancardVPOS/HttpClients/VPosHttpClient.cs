using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RugerTek.AspNetCore.BancardVPOS.Models.Api;

namespace RugerTek.AspNetCore.BancardVPOS.HttpClients
{
    internal class VPosHttpClient
    {
        private readonly HttpClient _httpClient;

        public VPosHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SingleBuy(SingleBuyApiModel body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/vpos/api/0.3/single_buy")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8)
            };
            return _httpClient.SendAsync(request, cancellationToken);
        }
        
        public Task<HttpResponseMessage> CardsNew()
    }
}