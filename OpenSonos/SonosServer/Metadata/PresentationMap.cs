using System;
using System.Xml.Serialization;

namespace OpenSonos.SonosServer.Metadata
{
    [Serializable]
    public class PresentationMap
    {
        [XmlAttribute("type")] 
        public string type;

        [XmlElement("Match")]  
        public MatchContainer Match;

        public static PresentationMap DefaultSonosSearch()
        {
            return new PresentationMap
            {
                type = "Search",
                Match = new MatchContainer
                {
                    SearchCategories = new SearchCategories
                    {
                        Category = new[]
                        {
                            new Category {id = "artists", mappedId = "artists"},
                            new Category {id = "albums", mappedId = "albums"},
                            new Category {id = "tracks", mappedId = "tracks"},
                            new Category {id = "playlists", mappedId = "playlists"},
                            new Category {id = "people", mappedId = "people"},
                        }
                    }
                }
            };
        }

        [Serializable]
        public class MatchContainer
        {
            [XmlElement("SearchCategories")] public SearchCategories SearchCategories;
        }

        [Serializable]
        public class SearchCategories
        {
            [XmlElement("Category")] public Category[] Category;
        }

        [Serializable]
        public class Category
        {
            [XmlAttribute("mappedId")] public string mappedId;
            [XmlAttribute("id")] public string id;
        }
    }
}
