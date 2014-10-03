using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenSonos.SonosServer;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.LocalMusicServer
{
    public class SonosId
    {
        public string RequestedId { get; private set; }
        public bool IsDirectory { get; private set; }

        public SonosId(string requestedId)
        {
            RequestedId = requestedId;
            if (!requestedId.EndsWith(".mp3"))
            {
                IsDirectory = true;
            }

            if (requestedId == "root")
            {
                RequestedId = "\\\\redqueen\\music";
            }
        }
    }

    public class FlatFileMusicCatalogue
    {
        public List<DirectoryEntry> GetCollection(SonosId id)
        {
            var dr = new List<DirectoryEntry>();

            if (id.IsDirectory)
            {
                dr.AddRange(Directory.GetDirectories(id.RequestedId).Select(subdir => new DirectoryEntry {IsDirectory = true, Path = subdir}));
                dr.AddRange(Directory.GetFiles(id.RequestedId).Select(subdir => new DirectoryEntry {IsDirectory = true, Path = subdir}));
            }

            return dr;
        }
    }


    public class DirectoryEntry
    {
        public bool IsDirectory { get; set; }
        public string Path { get; set; }
    }

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
            
           
            var collections = new List<mediaCollection>();
            var slice = directoryReference.Skip(request.index).Take(request.count);
            foreach (var subdirectory in slice.Where(x => x.IsDirectory))
            {
                var parts = subdirectory.Path.Split('\\');
                collections.Add(new mediaCollection
                {
                    artist = parts.Last(),
                    canPlay = false,
                    id = subdirectory.Path,
                    itemType = itemType.collection,
                    title = parts.Last()
                });
            }
            
            foreach (var entry in slice.Where(x => !x.IsDirectory))
            {
                var parts = entry.Path.Split('\\');
                collections.Add(new mediaCollection
                {
                    artist = parts.Last(),
                    canPlay = true,
                    id = entry.Path,
                    itemType = itemType.track,
                    title = parts.Last()
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
