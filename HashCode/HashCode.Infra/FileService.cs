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
		private const string InputFolder = @"D:\Dev\GoogleHashCode2020\Input\";
		private const string OutputFolder = @"D:\Dev\GoogleHashCode2020\Output\";

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
				var isFirstLine = true;
				var row = -1;

				while (line != null)
				{
					if (isFirstLine)
					{
						// TODO Add Firstline code
						//fileContents.AmountOfPhotos = Convert.ToInt32(line);
					}
					else
					{
						// TODO Add other lienss
						//var photoParameters = line.Split(' ').ToList();
						//var photo = new Photo()
						//{
						//	Id = row,
						//	IsHorizontal = photoParameters[0] == "H",
						//	NumberOfTags = Convert.ToInt32(photoParameters[1]),
						//	Tags = new List<string>()
						//};

						//for (var i = 2; i < photoParameters.Count; i++)
						//{
						//	photo.Tags.Add(photoParameters[i]);
						//}

						//photos.Add(photo);
					}

					line = file.ReadLine();
					isFirstLine = false;
					row++;
				}

				return fileContents;
			}
		}

		public void WriteFile(string inputFile, Output result)
		{

			var path = $"{OutputFolder}{inputFile.Substring(0, inputFile.IndexOf(".", StringComparison.Ordinal))}.out";

			
			var sb = new StringBuilder();

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

			File.AppendAllText(path, sb.ToString());
		}

		public List<string> GetInputFiles()
		{
			var inputFiles = Directory.GetFiles(InputFolder).Select(Path.GetFileName).ToList();

			return inputFiles;
		}
	}
}
