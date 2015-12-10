using System;
using System.Collections;
using System.Collections.Generic;
using Castle.Core.Internal;
using DesignPatterns;
using DesignPatterns.Structural.Repository;
using DesignPatterns.Utilities;
using DesignPatterns.Implementations;

namespace DesignPatternConsole.Structural.Programs
{
	public class RepositoryProgram : IRobotoProgram
	{
		private readonly IRobotoRepository _robotoRepository;
		private readonly IWriter _writer;
		private readonly IReader _reader;

		public RepositoryProgram(IRobotoRepository robotoRepository, IWriter writer, IReader reader)
		{
			_robotoRepository = robotoRepository;
			_writer = writer;
			_reader = reader;
		}

		public void Execute(System.Collections.Generic.IEnumerable<Roboto> robotos)
		{
			_writer.WriteLine("=== Running the Repository Program ===");

			string input = "";
			const string quitCommand = "q";
			const string listCommand = "list";
			const string saveCommand = "save";
			bool savedRoboto = false;

			while (input != quitCommand)
			{
				switch (input)
				{
					case listCommand:
						IEnumerable<Roboto> robotosInDatabase = _robotoRepository.RetrieveAll();
						robotosInDatabase.ForEach(x => _writer.WriteLine(String.Format("ID: {0} ::: Name: {1}", x.Id, x.Name)));
						break;
					case saveCommand:
						robotos.ForEach(x => _robotoRepository.Create(x));
						savedRoboto = true;
						_writer.WriteLine("Roboto saved!");
						break;

					default:
						break;
				}

				_writer.WriteLine("=== Choose a command ===");
				_writer.WriteLine(quitCommand + " -> quit");
				_writer.WriteLine(listCommand + " -> list all robotos");

				if (!savedRoboto)
				{
					_writer.WriteLine("save -> save the current roboto");
				}

				input = _reader.ReadLine();
			}

			_writer.WriteLine("Good bye! Press any key to close.");
			_reader.ReadLine();
		}
	}
}