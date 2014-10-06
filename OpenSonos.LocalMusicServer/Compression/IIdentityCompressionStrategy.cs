namespace OpenSonos.LocalMusicServer.Compression
{
    public interface IIdentityCompressionStrategy
    {
        string CompressString(string uncompressed);
        string TryDecompressString(string compressed);
    }
}