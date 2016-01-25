using DesignPatterns;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Utilities;
using System;

namespace DesignPatternConsole
{
	internal class ProgramFacade : IProgramFacade
	{
		private readonly IWriter _writer;
		private readonly IReader _reader;
		private readonly IRobotoProgramFactory _robotoProgramFactory;

		public ProgramFacade(IWriter writer, IReader reader, IRobotoProgramFactory robotoProgramFactory)
		{
			_writer = writer;
			_reader = reader;
			_robotoProgramFactory = robotoProgramFactory;
		}

		public void Execute()
		{
			// Get user input for creation method
			_writer.WriteLine("===== WELCOME TO ROBOTO-CON 2000! =====");

			while (RunProgram())
			{
				// REPL loop
			}
		}

		private bool RunProgram()
		{
			Type[] programs = _robotoProgramFactory.GetAvailableRobotoPrograms();

			// Get user input for program selection
			_writer.WriteLine("Please select a program to run");
			for (int i = 0; i < programs.Length; i++)
			{
				_writer.WriteLine(String.Format("{0} - {1}", i, programs[i].Name));
			}
			_writer.WriteLine("q - quit");
			_writer.WriteLine("=======================================");

			Type selectedProgramType = null;
			try
			{
				string input = _reader.ReadLine();

				if (input == "q")
				{
					return false;
				}

				int choice = Convert.ToInt32(input);
				selectedProgramType = programs[choice];
			}
			catch
			{
				_writer.WriteLine("Invalid input...good day!");
				_reader.ReadLine();
				return false;
			}

			// Execute selected program
			_writer.WriteLine(String.Format("=== Executing {0} ... ===", selectedProgramType.Name));
			IRobotoProgram robotoProgram = _robotoProgramFactory.GetRobotoProgram(selectedProgramType);
			robotoProgram.Execute();

			// Show final output
			_writer.WriteLine("=== Execution Complete...Press any key to continue===");
			_reader.ReadLine();

			return true;
		}
	}
}