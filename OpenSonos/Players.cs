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

        public async static Task<List<SonosPlayer>> DiscoverPlayers()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var serverIp = host.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            var subnet = string.Join(".", serverIp.ToString().Split('.').Take(3));

            var sonosPlayers = new List<SonosPlayer>();

            var http = new HttpClient();
            for (var ipPart = 1; ipPart < 256; ipPart++)
            {
                var ip = subnet + "." + ipPart;
                var response = await http.GetAsync(string.Format("http://{0}:1400/customsd.htm", ip));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    sonosPlayers.Add(new SonosPlayer(ip));
                }
            }

            return sonosPlayers;
        }
    }
}