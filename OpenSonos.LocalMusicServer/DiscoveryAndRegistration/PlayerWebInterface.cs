using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.DiscoveryAndRegistration
{
    public class PlayerWebInterface
    {
        private readonly ServerConfiguration _config;

        #if DEBUG
        private const string ServerName = "LANServer_Dev_vNext";
        private const string Sid = "244";
        #else
        private const string ServerName = "LANServer_vNext";
        private const string Sid = "245";
#endif

		public PlayerWebInterface(ServerConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> RegisterServer(SonosPlayer player, IPAddress serverIp)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format("http://{0}:1400/customsd", player.Address))
            {
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("sid", Sid),
                    new KeyValuePair<string, string>("name", ServerName),
                    new KeyValuePair<string, string>("uri", _config.ServerRoot + "/sonos-api"),
                    new KeyValuePair<string, string>("secureUri", _config.ServerRoot + "/sonos-api"),
                    new KeyValuePair<string, string>("pollInterval", "900"),
                    new KeyValuePair<string, string>("authType", "UserId"),
                    new KeyValuePair<string, string>("stringsVersion", "0"),
                    new KeyValuePair<string, string>("stringsUri", ""),
                    new KeyValuePair<string, string>("presentationMapVersion", "10"),
                    new KeyValuePair<string, string>("presentationMapUri", _config.ServerRoot + "/metadata/presentation-maps"),
                    new KeyValuePair<string, string>("containerType", "SoundLab"),
                    new KeyValuePair<string, string>("caps", "search"),
                    new KeyValuePair<string, string>("caps", "extendedMD"),
                    new KeyValuePair<string, string>("caps", "mediaUriActions"),
                })
            };

            var response = await Process(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<HttpResponseMessage> Process(HttpRequestMessage request)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));

            var channel = new HttpClient();
            return await channel.SendAsync(request);
        }
    }
}