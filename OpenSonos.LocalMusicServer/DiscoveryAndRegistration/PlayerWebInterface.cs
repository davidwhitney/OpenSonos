using System.Net;
using System.Net.Http;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.DiscoveryAndRegistration
{
    public class PlayerWebInterface
    {
        private readonly ServerConfiguration _config;

        public PlayerWebInterface(ServerConfiguration config)
        {
            _config = config;
        }

        public void RegisterServer(SonosPlayer player, IPAddress serverIp)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format("http://{0}:1400/customsd", player.Address));
            request.Properties.Add("sid", "255");
            request.Properties.Add("name", "LANServer");
            request.Properties.Add("uri", _config.ServerRoot + "/sonos-api");
            request.Properties.Add("secureUri", _config.ServerRoot + "/sonos-api");
            request.Properties.Add("pollInterval", "900");
            request.Properties.Add("authType", "UserId");
            request.Properties.Add("stringsVersion", "0");
            request.Properties.Add("stringsUri", "");
            request.Properties.Add("presentationMapVersion", "10");
            request.Properties.Add("presentationMapUri", _config.ServerRoot + "/metadata/presentation-maps");
            request.Properties.Add("containerType", "SoundLab");
            request.Properties.Add("caps", "search");
            request.Properties.Add("caps", "extendedMD");
            request.Properties.Add("caps", "mediaUriActions");
        }
    }
}