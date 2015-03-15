using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenSonos.LocalMusicServer.Bootstrapping;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.Test.Unit.Browsing
{
    [TestFixture]
    public class IdentityProviderTests
    {
        private string _uncompressedId;
        private IIdentityProvider _provider;
	    private ServerConfiguration _config;
        private string _compressedId;

        [SetUp]
        public void SetUp()
        {
            _uncompressedId = "\\\\some\\smb\\path";
	        _compressedId = new Sha1ConvertPathsToIdentifiers().IdentifierFor(_uncompressedId);

            var backing = new Dictionary<string, SonosIdentifier>
            {
                {_uncompressedId, new SonosIdentifier {Id = _compressedId, Path = "\\\\some\\smb\\path"}}
            };

	        _config = new ServerConfiguration {MusicShare = "\\\a\\\\b"};
            _provider = new IdentityProvider(_config, backing);
        }

        [Test]
        public void FromPath_WithPath_IdAndPathSetCorrectly()
        {
            var identifier = _provider.IdFor(_uncompressedId);

            Assert.That(identifier.Id, Is.EqualTo(_compressedId));
        }

        [Test]
        public void FromPath_WithMaxWindowsPathLength_CanCreateCompressedId()
        {
            var identifier = _provider.IdFor("\\abcdefghjklmnopqrstuvwxyz\\ABCDEFGHIJKLMNOPQRSTUVWXYZ\\AbCdEfGhIjLlMnoPqRsTuVwZyZ\\the quick brown fox jumped ov\\er the lazy dog and this i\\s strin  a long string th\\at should be very hard toc\\ompress reliably for gzip \\compression to handle well and q");

            Assert.That(identifier.Id, Is.Not.Null);
        }

        [Test]
        public void FromPath_WhenPathHasLotsOfEntropy_CanCreateCompressedId()
        {
            var identifier = _provider.IdFor("Justin Timberlake - The 20-20 Experience (Deluxe Edition) 2013 Pop 320kbps CBR MP3 [VX]");

            Assert.That(identifier.Id, Is.Not.Null);
        }

        [Test]
        public void FromPath_WhenPathIsProvidedTwice_SameIdReturned()
        {
            var identifier1 = _provider.IdFor("\\something\\here");
            var identifier2 = _provider.IdFor("\\something\\here");

            Assert.That(identifier1.Id, Is.EqualTo(identifier2.Id));
            Assert.That(identifier1.Path, Is.EqualTo(identifier2.Path));
        }

        [Test]
        public void FromRequestId_WithValidCompressedId_PathIsCorrect()
        {
            var identifier = _provider.FromRequestId(_compressedId);

            Assert.That(identifier.Path, Is.EqualTo(_uncompressedId));
        }

        [Test]
        public void FromRequestId_WithNullEmptyId_ReturnsNull()
        {
            var identifier = _provider.FromRequestId("");

            Assert.That(identifier, Is.Null);
        }

        [Test]
        public void FromRequestId_WithUnrecognisedPath_ReturnsNull()
        {
            var identifier = _provider.FromRequestId("random-thing-here");

            Assert.That(identifier, Is.Null);
        }

        [Test]
        public void FromRequestId_WithRootPath_ReturnsRootId()
        {
            var identifier = _provider.FromRequestId("root");
			
            Assert.That(identifier.Id, Is.EqualTo(Guid.Empty.ToString()));
            Assert.That(identifier.Path, Is.EqualTo(_config.MusicShare));
            Assert.That(identifier.IsDirectory, Is.True);
        }

        [Test]
        public void FromRequestId_WithDirectoryPath_IsDirectoryIsTrue()
        {
            var identifier = _provider.FromRequestId(_compressedId);

            Assert.That(identifier.IsDirectory, Is.EqualTo(true));
        }
    }
}
