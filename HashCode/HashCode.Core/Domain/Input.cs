using System.Collections.Generic;

namespace HashCode.Core.Domain
{
	public class Input
	{
		public Input()
		{
			Books = new List<int>();
			Libraries = new List<Library>();
		}

		public int NumberOfBooks { get; set; }
		public int NumberOfLibraries { get; set; }
		public int Days { get; set; }
		public List<int> Books { get; set; }
		public List<Library> Libraries { get; set; }
	}
}
