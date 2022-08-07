using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RugerTek.AspNetCore.BancardVPOS.Helpers
{
    internal static class HttpContentHelpers
    {
        public static async ValueTask<T> ReadAsAsync<T>(this HttpContent content, CancellationToken cancellationToken = default)
        {
            var readTask = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(readTask, null, cancellationToken);
        }
    }
}