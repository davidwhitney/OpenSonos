using NUnit.Framework;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.Smapi;
using OpenSonos.SonosServer;
using Container = OpenSonos.LocalMusicServer.Browsing.Container;

namespace OpenSonos.LocalMusicServer.Test.Unit.Smapi
{
    [TestFixture]
    public class ResponseFormattingExtensionsTests
    {
		private ResourceCollection _fileEntries;
		private ResourceCollection _directoryEntries;

        [SetUp]
        public void SetUp()
        {
            _fileEntries = new ResourceCollection { new MusicFile(new SonosIdentifier {Id = "1", Path = "\\\\some\\file.mp3"}) };
			_directoryEntries = new ResourceCollection { new Container(new SonosIdentifier { Id = "1", Path = "\\\\some\\path" }) }; 
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_SingleEntryReturnedWithCorrectMetadata()
        {
            var result = _fileEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items.Length, Is.EqualTo(1));
            Assert.That(result.count, Is.EqualTo(1));
            Assert.That(result.index, Is.EqualTo(0));
            Assert.That(result.total, Is.EqualTo(1));
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_PropertiesMappedCorrectly()
        {
            var result = _fileEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items[0].id, Is.EqualTo("1"));
            Assert.That(result.Items[0].title, Is.EqualTo("file.mp3"));
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_ItemReturnedIsMediaMetadata()
        {
            var result = _fileEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items[0], Is.TypeOf<mediaMetadata>());
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForAFile_MediaMetadataIsCorrect()
        {
            var result = _fileEntries.DirectoryToSonosResponse(0, 1);

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
        
        [Test]
        public void DirectoryToSonosResponse_SingleResourceForADirectory_SingleEntryReturnedWithCorrectMetadata()
        {
            var result = _directoryEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items.Length, Is.EqualTo(1));
            Assert.That(result.count, Is.EqualTo(1));
            Assert.That(result.index, Is.EqualTo(0));
            Assert.That(result.total, Is.EqualTo(1));
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForADirectory_PropertiesMappedCorrectly()
        {
            var result = _directoryEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items[0].id, Is.EqualTo("1"));
            Assert.That(result.Items[0].title, Is.EqualTo("path"));
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForADirectory_ItemReturnedIsAMediaCollection()
        {
            var result = _directoryEntries.DirectoryToSonosResponse(0, 1);

            Assert.That(result.Items[0], Is.TypeOf<mediaCollection>());
        }

        [Test]
        public void DirectoryToSonosResponse_SingleResourceForADirectory_MediaCollectionIsCorrect()
        {
            var result = _directoryEntries.DirectoryToSonosResponse(0, 1);

            var mmd = (mediaCollection)result.Items[0];
            Assert.That(mmd.canPlay, Is.True);
            Assert.That(mmd.canEnumerate, Is.True);
            Assert.That(mmd.itemType, Is.EqualTo(itemType.collection));
        }
    }
}
