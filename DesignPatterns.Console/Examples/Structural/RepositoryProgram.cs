using BuilderPatterns.AbstractFactory;
using Castle.Core.Internal;
using DesignPatterns;
using DesignPatterns.Implementations;
using DesignPatterns.Structural.Repository;
using DesignPatterns.Utilities;
using System;
using System.Collections.Generic;

namespace DesignPatternConsole.Examples.Structural
{
	public class RepositoryProgram : IRobotoProgram
	{
		private readonly IRobotoRepository _robotoRepository;
		private readonly IRobotoFactory _robotoFactory;
		private readonly IWriter _writer;
		private readonly IReader _reader;

		public RepositoryProgram(IRobotoRepository robotoRepository, IRobotoFactory robotoFactory, IWriter writer, IReader reader)
		{
			_robotoRepository = robotoRepository;
			_robotoFactory = robotoFactory;
			_writer = writer;
			_reader = reader;
		}

		public void Execute()
		{
			_writer.WriteLine("=== Running the Repository Program ===");
			Roboto[] robotos = new[]
			{
				_robotoFactory.CreateHumanoidRoboto(),
				_robotoFactory.CreateRollingRoboto()
			};

			string input = "";
			const string quitCommand = "q";
			const string listCommand = "l";
			const string saveCommand = "s";
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