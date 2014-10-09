using System.Collections.Generic;
using NUnit.Framework;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.MusicDatabase;
using OpenSonos.LocalMusicServer.Smapi;
using OpenSonos.SonosServer;

namespace OpenSonos.LocalMusicServer.Test.Unit.Smapi
{
    [TestFixture]
    public class MappingExtensionsTests
    {
        private MusicFile _musicFile;

        [SetUp]
        public void SetUp()
        {
            _musicFile = new MusicFile(new SonosIdentifier {Id = "1", Path = "\\\\some\\file.mp3"});
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_SingleEntryReturnedWithCorrectMetadata()
        {
            var directoryEntries = new List<IRepresentAResource> { _musicFile }; 

            var result = directoryEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items.Length, Is.EqualTo(1));
            Assert.That(result.count, Is.EqualTo(1));
            Assert.That(result.index, Is.EqualTo(0));
            Assert.That(result.total, Is.EqualTo(1));
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_PropertiesMappedCorrectly()
        {
            var directoryEntries = new List<IRepresentAResource> { _musicFile };

            var result = directoryEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items[0].id, Is.EqualTo("1"));
            Assert.That(result.Items[0].title, Is.EqualTo("file.mp3"));
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_ItemReturnedIsMediaMetadata()
        {
            var directoryEntries = new List<IRepresentAResource> { _musicFile };

            var result = directoryEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items[0], Is.TypeOf<mediaMetadata>());
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_MediaMetadataIsCorrect()
        {
            var directoryEntries = new List<IRepresentAResource> { _musicFile };

            var result = directoryEntries.DirectoryToSonosResponse(0, 1);

            var mmd = (mediaMetadata) result.Items[0];
            var meta = (trackMetadata) mmd.Item;
            Assert.That(mmd.mimeType, Is.EqualTo("audio/mpeg3"));
            Assert.That(mmd.itemType, Is.EqualTo(itemType.track));
            Assert.That(meta.canPlay, Is.True);
            Assert.That(meta.canSkip, Is.True);
            Assert.That(meta.canPlay, Is.True);
            Assert.That(meta.canPlaySpecified, Is.True);
            Assert.That(meta.canSkipSpecified, Is.True);
        }
    }
}
