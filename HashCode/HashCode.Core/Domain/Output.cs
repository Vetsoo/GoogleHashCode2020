using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode.Core.Domain
{
	public class Output
	{
        public List<Tuple<int, int[]>> LibraryAndBooksOrder { get; set; }

        public string PrintOutput()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{LibraryAndBooksOrder.Count}");
            foreach(var item in LibraryAndBooksOrder)
            {
                builder.AppendLine($"{item.Item1} {item.Item2.Length}");
                foreach(var book in item.Item2)
                {
                    builder.Append($"{book} ");
                }                
            }

            return builder.ToString();
            
        }

        
    }
}
