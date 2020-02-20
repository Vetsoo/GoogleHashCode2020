using HashCode.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HashCode.Infra
{
	public class FileService
	{
        private const string InputFolder = @"C:\Users\bdt\GoogleHashCode2020\HashCode\HashCode.Console\Input\";
        private const string OutputFolder = @"C:\Users\bdt\GoogleHashCode2020\HashCode\HashCode.Console\Output\";


        public Input ReadFile(string fileName)
		{
			var path = $"{InputFolder}{fileName}";

			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"{DateTime.Now}: file \"{fileName}\" is not found in folder \"{InputFolder}\"");
			}

			using (var file = File.OpenText(path))
			{
				var fileContents = new Input();
				var line = file.ReadLine();
				var lineCounter = 1;
				var libraryId = 0;
				var bookId = 0;

				while (line != null)
				{
					if (string.IsNullOrEmpty(line))
					{
						line = file.ReadLine();
						lineCounter++;
						continue;
					}

					if (lineCounter == 1)
					{
						var fileParameters = line.Split(' ').ToList();
						fileContents.NumberOfBooks = Convert.ToInt32(fileParameters[0]);
						fileContents.NumberOfLibraries = Convert.ToInt32(fileParameters[1]);
						fileContents.Days = Convert.ToInt32(fileParameters[2]);
					}
					else if (lineCounter == 2)
					{
						var fileParameters = line.Split(' ').ToList();
						foreach (var param in fileParameters)
						{
							var book = new Book();
							book.BookId = bookId;
							book.Score = Convert.ToInt32(param);
							fileContents.Books.Add(book);
							bookId++;
						}
					}
					else
					{

						var library = new Library();
						var fileParameters = line.Split(' ').ToList();
						try
						{
							library.AmountOfBooks = Convert.ToInt32(fileParameters[0]);
							library.SignUpProcess = Convert.ToInt32(fileParameters[1]);
							library.BooksPerDay = Convert.ToInt32(fileParameters[2]);
							library.LibraryId = libraryId;

							// Read next line
							line = file.ReadLine();
							fileParameters = line.Split(' ').ToList();

							foreach (var param in fileParameters)
							{
								library.BookIds.Add(Convert.ToInt32(param));
							}

							fileContents.Libraries.Add(library);
							libraryId++;
						}
						catch (Exception ex)
						{
							throw ex;
						}
					}

					line = file.ReadLine();
					lineCounter++;
				}

				return fileContents;
			}
		}

		public void WriteFile(string inputFile, string result)
		{

			var path = $"{OutputFolder}{inputFile.Substring(0, inputFile.IndexOf(".", StringComparison.Ordinal))}.out";

			// TODO Append results
			//sb.Append($"{result.Slides.Count}\n");

			//foreach (var slide in result.Slides)
			//{
			//	if (slide.Photos.Count == 2)
			//	{
			//		sb.Append($"{slide.Photos[0].Id} {slide.Photos[1].Id}\n");
			//	}
			//	else
			//	{
			//		sb.Append($"{slide.Photos[0].Id}\n");
			//	}
			//}

			File.AppendAllText(path, result);
		}

		public List<string> GetInputFiles()
		{
			var inputFiles = Directory.GetFiles(InputFolder).Select(Path.GetFileName).ToList();

			return inputFiles;
		}
	}
}
