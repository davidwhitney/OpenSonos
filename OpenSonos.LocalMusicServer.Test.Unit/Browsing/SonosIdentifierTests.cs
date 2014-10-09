using NUnit.Framework;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.Test.Unit.Browsing
{
    [TestFixture]
    public class SonosIdentifierTests
    {
        [TestCase("\\\\some\\path", true)]
        [TestCase("\\\\some\\path\\file.mp3", false)]
        public void CreatedWithAPath_IsDirectoryIsAccurate(string path, bool isDirectory)
        {
            var si = new SonosIdentifier {Path = path};

            Assert.That(si.IsDirectory, Is.EqualTo(isDirectory));
        }
    }
}
