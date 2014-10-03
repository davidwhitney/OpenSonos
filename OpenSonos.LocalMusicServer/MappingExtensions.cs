using System.Collections.Generic;
using System.Linq;
using OpenSonos.LocalMusicServer.MusicDatabase;
using OpenSonos.SonosServer;

namespace OpenSonos.LocalMusicServer
{
    public static class MappingExtensions
    {
        public static mediaMetadata ToMediaMetadata(this IRepresentAResource entry)
        {
            return new mediaMetadata
            {
                itemType = itemType.track,
                id = entry.Id,
                title = entry.DisplayName,
                onDemand = true,
                onDemandSpecified = true,
                mimeType = "audio/mpeg3",
                Item = new trackMetadata
                {
                    canPlay = true,
                    canPlaySpecified = true,
                    albumId = entry.Id
                }
            };
        }

        public static mediaList DirectoryToSonosResponse(this List<IRepresentAResource> directoryEntries, int index, int count)
        {
            var requestedPage = directoryEntries.Skip(index).Take(count).ToList();

            var collections = new List<AbstractMedia>();
            foreach (var subdirectory in requestedPage.Where(x => x is Container))
            {
                collections.Add(new mediaCollection
                {
                    artist = subdirectory.DisplayName,
                    canPlay = false,
                    id = subdirectory.Id,
                    itemType = itemType.album,
                    title = subdirectory.DisplayName,
                    readOnly = true,
                    userContent = true,
                    homogeneous = true,
                    canEnumerate = true
                });
            }

            foreach (var entry in requestedPage.Where(x => x is MusicFile))
            {
                collections.Add(entry.ToMediaMetadata());
            }

            return new mediaList
            {
                count = count,
                index = index,
                Items = collections.ToArray(),
                total = directoryEntries.Count
            };
        }
    }
}