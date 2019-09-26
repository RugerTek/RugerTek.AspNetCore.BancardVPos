using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RugerTek.AspNetCore.BancardVPOS.Helpers
{
    internal static class HttpContentHelpers
    {
        public static ValueTask<T> ReadAsAsync<T>(this HttpContent content, CancellationToken cancellationToken = default)
        {
            var readTask = content.ReadAsStreamAsync();
            Task.WaitAll(readTask);
            return JsonSerializer.DeserializeAsync<T>(readTask.Result, null, cancellationToken);
        }
    }
}