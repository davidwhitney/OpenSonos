using System;
using System.Security.Cryptography;
using System.Text;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class ConvertPathsToSha1
    {
        private readonly SHA1CryptoServiceProvider _sha;

        public ConvertPathsToSha1()
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