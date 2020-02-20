using HashCode.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace HashCode.Infra
{
	public class AlgorithmService
	{

        private Input _input = null;

        public AlgorithmService(Input input)
        {
            _input = input;
        }

        public void RunAlgorithm1()
        {
            List<MaxThroughputLibrary> maxThrouhgputItem = new List<MaxThroughputLibrary>();
            foreach(var library in _input.Libraries)
            {
                var daysToScan = _input.Days - library.SignUpProcess;
                var scannableBooks = daysToScan * library.BooksPerDay;

                if(scannableBooks > library.AmountOfBooks)
                {
                    scannableBooks = library.AmountOfBooks;
                }

                maxThrouhgputItem.Add(new MaxThroughputLibrary
                {
                    LibraryId = library.Id,
                    Throughput = scannableBooks
                });
            }

            maxThrouhgputItem.OrderByDescending(x => x.Throughput);
        }       

	}
}
