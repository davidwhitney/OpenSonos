using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenSonos
{
    public static class Players
    {
        public static async void Discover(IPAddress currentIp, Action<SonosPlayer> andThen = null)
        {
            andThen = andThen ?? (p => { });

            var subnet = string.Join(".", currentIp.ToString().Split('.').Take(3));
            for (var ipPart = 1; ipPart < 256; ipPart++)
            {
                var ip = subnet + "." + ipPart;
                await SpawnAsyncTaskToScanForSonos(andThen, ip);
            }
        }

        private static async Task SpawnAsyncTaskToScanForSonos(Action<SonosPlayer> andThen, string ip)
        {
            await Task.Run(() =>
            {
                ScanForSonos(ip).ContinueWith(t =>
                {
                    if (t.Result != SonosPlayer.None)
                    {
                        andThen(t.Result);
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            });
        }

        private static async Task<SonosPlayer> ScanForSonos(string ip)
        {
            var request = new HttpRequestMessage(HttpMethod.Head, string.Format("http://{0}:1400/xml/device_description.xml", ip));
            var response = await TrySend(request);
            return response != null && response.StatusCode == HttpStatusCode.OK
                ? new SonosPlayer(ip)
                : SonosPlayer.None;
        }

        public static async Task<HttpResponseMessage> TrySend(HttpRequestMessage request)
        {
            var http = new HttpClient { Timeout = new TimeSpan(0, 0, 0, 0, 150) };

            try
            {
                return await http.SendAsync(request);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}