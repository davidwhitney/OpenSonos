using NUnit.Framework;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.MusicDatabase;

namespace OpenSonos.LocalMusicServer.Test.Unit.MusicDatabase
{
    [TestFixture]
    public class PhysicalResourceTests
    {
        [Test]
        public void FromId_IdIsForAPath_ReturnsAContainer()
        {
            var id = new SonosIdentifier {Path = "\\abc\\def"};

            var resource = PhysicalResource.FromId(id);

            Assert.That(resource, Is.TypeOf<Container>());
            Assert.That(resource.DisplayName, Is.EqualTo("def"));
        }

        [Test]
        public void FromId_IdIsForAFile_ReturnsAContainer()
        {
            var id = new SonosIdentifier {Path = "\\abc\\def.mp3"};

            var resource = PhysicalResource.FromId(id);

            Assert.That(resource, Is.TypeOf<MusicFile>());
            Assert.That(resource.DisplayName, Is.EqualTo("def.mp3"));
        }
    }
}
