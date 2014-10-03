using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSonos.SonosServer
{
    public class PresentationMap
    {
        public string type { get; set; }
        public Match Match { get; set; }

        public static PresentationMap DefaultSonosSearch()
        {
            return new PresentationMap
            {
                type = "Search",
                Match = new Match
                {
                    SearchCategories = new Searchcategories
                    {
                        Category = new[]
                        {
                            new Category{id = "artists", mappedId = "artists"},
                            new Category{id = "albums", mappedId = "albums"},
                            new Category{id = "tracks", mappedId = "tracks"},
                            new Category{id = "playlists", mappedId = "playlists"},
                            new Category{id = "people", mappedId = "people"},
                        }
                    }
                }
            };
        }
    }

    public class Match
    {
        public Searchcategories SearchCategories { get; set; }
    }

    public class Searchcategories
    {
        public Category[] Category { get; set; }
    }

    public class Category
    {
        public string mappedId { get; set; }
        public string id { get; set; }
    }

}
