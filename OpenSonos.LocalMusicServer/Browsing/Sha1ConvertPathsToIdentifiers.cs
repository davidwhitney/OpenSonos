using System;
using System.Security.Cryptography;
using System.Text;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class Sha1ConvertPathsToIdentifiers
    {
        private readonly SHA1CryptoServiceProvider _sha;

        public Sha1ConvertPathsToIdentifiers()
        {
            _sha = new SHA1CryptoServiceProvider();
        }

        public string IdentifierFor(string path)
        {
            var bytes = _sha.ComputeHash(Encoding.ASCII.GetBytes(path));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}