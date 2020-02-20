using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode.Core.Domain
{
    public class CalculatedLibrary
    {
		public CalculatedLibrary()
		{
			BookIds = new List<int>();
		}
		public int AmountOfBooks { get; set; }
		public int SignUpProcess { get; set; }
		public int BooksPerDay { get; set; }
		public List<int> BookIds { get; set; }
		public int LibraryId { get; set; }
		public int TotalTimeNeeded { get; set; }
        public int TotalPointsOfLibrary { get; set; }
        public int Throughput { get; set; }

	}
}
