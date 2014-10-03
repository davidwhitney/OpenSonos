﻿using System;
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
        public static List<SonosPlayer> Discover()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var serverIp = host.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            var subnet = string.Join(".", serverIp.ToString().Split('.').Take(3));

            var sonosPlayers = new List<SonosPlayer>();
            var scaningTasks = new List<Task>();
            for (var ipPart = 1; ipPart < 256; ipPart++)
            {
                var ip = subnet + "." + ipPart;
                var task = Task.Run(() => ScanForSonos(ip, sonosPlayers));
                scaningTasks.Add(task);
            }

            Task.WaitAll(scaningTasks.ToArray());

            return sonosPlayers;
        }

        private static async void ScanForSonos(string ip, ICollection<SonosPlayer> sonosPlayers)
        {
            var request = new HttpRequestMessage(HttpMethod.Head,
                string.Format("http://{0}:1400/xml/device_description.xml", ip));

            var response = await TrySend(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Sonos found at " + ip);
                sonosPlayers.Add(new SonosPlayer(ip));
            }
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