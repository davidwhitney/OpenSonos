using System.Net;
using NUnit.Framework;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.Test.Unit.Bootstrapping
{
    [TestFixture]
    public class ServerConfigurationTests
    {
        [Test]
        public void ServerRoot_CalculatedBaseOnServerIpAndPort()
        {
            var sc = new ServerConfiguration
            {
                ServerIp = IPAddress.Parse("127.0.0.1"),
                BasePort = "80"
            };

            Assert.That(sc.ServerRoot, Is.EqualTo("http://127.0.0.1:80"));
        }
    }
}
