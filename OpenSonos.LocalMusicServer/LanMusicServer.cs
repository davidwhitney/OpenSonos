using System;
using System.Collections.Generic;
using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.MusicDatabase;
using OpenSonos.SonosServer;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.LocalMusicServer
{
    public class LanMusicServer : ServerBase
    {
        public override Presentation GetPresentationMaps()
        {
            return new Presentation
            {
                PresentationMaps = new List<PresentationMap>
                {
                    PresentationMap.DefaultSonosSearch()
                }
            };
        }

        public override getSessionIdResponse GetSessionId(getSessionIdRequest request)
        {
            return new getSessionIdResponse("1");
        }

        public override getMetadataResponse GetMetadata(getMetadataRequest request)
        {
            var id = new SonosId(request.id);
            var catalogue = new FlatFileMusicCatalogue();
            var directoryReference = catalogue.GetCollection(id);
            
            var collections = new List<AbstractMedia>();
            var slice = directoryReference.Skip(request.index).Take(request.count);
            foreach (var subdirectory in slice.Where(x => x.IsDirectory))
            {
                var parts = subdirectory.Path.Split('\\');
                collections.Add(new mediaCollection
                {
                    artist = parts.Last(),
                    canPlay = false,
                    id = subdirectory.Id,
                    itemType = itemType.collection,
                    title = parts.Last()
                });
            }
            
            foreach (var entry in slice.Where(x => !x.IsDirectory))
            {
                var parts = entry.Path.Split('\\');
                collections.Add(new mediaMetadata
                {
                    itemType =  itemType.track,
                    id = entry.Id,
                    title = parts.Last(),
                    Item = new trackMetadata
                    {
                        canPlay = true
                    }
                });
            }
            
            var ml = new mediaList
            {
                count = request.count,
                index = request.index,
                Items = collections.ToArray(),
                total = directoryReference.Count
            };

            return new getMetadataResponse(ml);
        }

        public override getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public override getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public override getMediaURIResponse GetMediaUri(getMediaURIRequest request)
        {
            throw new NotImplementedException();
        }

        public override getLastUpdateResponse GetLastUpdate(getLastUpdateRequest request)
        {
            return new getLastUpdateResponse
            {
                getLastUpdateResult = new lastUpdate
                {
                    catalog = DateTime.UtcNow.Ticks.ToString(),
                    favorites = "1"
                }
            };
        }

        public override searchResponse Search(searchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
