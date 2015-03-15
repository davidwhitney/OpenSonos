using System.Collections.Generic;

namespace OpenSonos.LocalMusicServer.Browsing
{
	public class ResourceCollection : List<IRepresentAResource>
	{
		public SonosIdentifier Identifier { get; set; }

		public ResourceCollection(SonosIdentifier identifier, IEnumerable<IRepresentAResource> enumerable)
			: this(identifier)
		{
			AddRange(enumerable);
		}

		public ResourceCollection(SonosIdentifier identifier)
		{
			Identifier = identifier;
		}

		public ResourceCollection()
		{
		}
	}
}