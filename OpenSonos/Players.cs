using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace OpenSonos
{
    public static class Players
    {

        public async static Task<List<SonosPlayer>> Discover()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var serverIp = host.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            var subnet = string.Join(".", serverIp.ToString().Split('.').Take(3));

            var sonosPlayers = new List<SonosPlayer>();

            for (var ipPart = 1; ipPart < 256; ipPart++)
            {
                var ip = subnet + "." + ipPart;

                var request = new HttpRequestMessage(HttpMethod.Head, string.Format("http://{0}:1400/customsd.htm", ip));
                var response = await TrySend(request);
                
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    sonosPlayers.Add(new SonosPlayer(ip));
                }
            }

            return sonosPlayers;
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