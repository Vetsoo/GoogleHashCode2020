using System.Collections.Generic;

namespace HashCode.Core.Domain
{
	public class Library
	{
		public Library()
		{
			BookIds = new List<int>();
		}
		public int LibraryId { get; set; }
		public int AmountOfBooks { get; set; }
		public int SignUpProcess { get; set; }
		public int BooksPerDay { get; set; }
		public List<int> BookIds { get; set; }
        public List<Book> Books { get; set; }
	}
}
