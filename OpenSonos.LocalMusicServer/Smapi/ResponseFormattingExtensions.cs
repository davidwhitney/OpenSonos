﻿using System.Collections.Generic;
using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.SonosServer;

namespace OpenSonos.LocalMusicServer.Smapi
{
    public static class ResponseFormattingExtensions
    {
        public static mediaMetadata ToMediaMetadata(this IRepresentAResource entry)
        {
            return new mediaMetadata
            {
                itemType = itemType.track,
                id = entry.Identifier.Id,
                title = entry.DisplayName,
                mimeType = "audio/mpeg3",
                Item = new trackMetadata
                {
                    canSkip = true,
                    canAddToFavorites = true,
                    canSkipSpecified = true,
                    canPlay = true,
                    canPlaySpecified = true,
                }
            };
        }

        public static mediaList ToMediaList(this ResourceCollection directoryEntries, int index, int count)
        {
            var requestedPage = directoryEntries.Skip(index).Take(count).ToList();

            var collections = new List<AbstractMedia>();
            foreach (var subdirectory in requestedPage.Where(x => x is Container))
            {
                collections.Add(new mediaCollection
                {
                    id = subdirectory.Identifier.Id,
                    title = subdirectory.DisplayName,
                    itemType = itemType.collection,
                    canEnumerate = true,
                    canPlay = true
                });
            }
            
            foreach (var entry in requestedPage.Where(x => x is MusicFile))
            {
				var meta = entry.ToMediaMetadata();

                ((trackMetadata) meta.Item).albumId = null != directoryEntries.Identifier
                    ? directoryEntries.Identifier.Id
                    : null;

	            collections.Add(meta);
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