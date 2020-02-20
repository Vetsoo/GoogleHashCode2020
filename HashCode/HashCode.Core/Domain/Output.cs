using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode.Core.Domain
{
	public class Output
	{
        public List<Tuple<int, int[]>> LibraryAndBooksOrder { get; set; }

        public string PrintOutput(List<Tuple<int, int[]>> libraryAndBooksOrder)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{libraryAndBooksOrder.Count}");
            foreach(var item in libraryAndBooksOrder)
            {
                builder.AppendLine($"{item.Item1}{item.Item2.Length}");
                foreach(var book in item.Item2)
                {
                    builder.Append($"{book}");
                }                
            }

            return builder.ToString();
            
        }

        
    }
}
