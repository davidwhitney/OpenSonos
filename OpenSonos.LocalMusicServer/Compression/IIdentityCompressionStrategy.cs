namespace OpenSonos.LocalMusicServer.Compression
{
    public interface IIdentityCompressionStrategy
    {
        string CompressString(string uncompressed);
        string DecompressString(string compressedText);
        string TryDecompressString(string compressed);
    }
}