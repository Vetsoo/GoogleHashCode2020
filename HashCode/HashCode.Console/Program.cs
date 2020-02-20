namespace HashCode.Console
{
    using HashCode.Core.Domain;
    using HashCode.Infra;
	using System;

	public class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Would you like to run all files, or a single file? (A/S)");
				var allOrSingle = Console.ReadLine();

				switch (allOrSingle)
				{
					case "A":
						Program.RunAllFiles();
						break;
					case "S":
						Console.WriteLine("Choose which code you would like to run:");
						var fileName = Console.ReadLine();
						Program.RunSingleFile(fileName);
						break;
					default:
						throw new NotImplementedException();
				}

			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
			finally
			{
				Console.ReadLine();
			}
		}

		private static void RunAllFiles()
		{
			var fileService = new FileService();
			var inputFiles = fileService.GetInputFiles();
			inputFiles.Sort();

			for (int i = 0; i < inputFiles.Count; i++)
			{
				Program.RunSingleFile(inputFiles[i]);
			}
		}

		private static void RunSingleFile(string fileName)
		{
			var fileService = new FileService();

			var fileContents = fileService.ReadFile(fileName);

			Console.WriteLine($"File {fileName} has been read out.");

			Console.WriteLine($"Amount of Books: {fileContents.Books.Count}");
			Console.WriteLine();

			var algorithmService = new AlgorithmService(fileContents);

			//TODO Execute algorithm
			var result = new Output();

			//TODO Write correct solution to file
			fileService.WriteFile(fileName, result);
		}
	}
}
