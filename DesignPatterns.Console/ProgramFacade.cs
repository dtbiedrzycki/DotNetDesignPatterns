using System;
using Castle.Windsor;
using DesignPatterns;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Utilities;

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

			Type[] programs = _robotoProgramFactory.GetAvailableRobotoPrograms();

			// Get user input for program selection
			_writer.WriteLine("Please select a program to run");
			for (int i = 0; i < programs.Length; i++)
			{
				_writer.WriteLine(String.Format("{0} - {1}", i, programs[i].Name));
			}
			_writer.WriteLine("=======================================");

			Type selectedProgramType = null;
			try
			{
				string input = _reader.ReadLine();

				int choice = Convert.ToInt32(input);
				selectedProgramType = programs[choice];
			}
			catch
			{
				_writer.WriteLine("Invalid input...good day!");
				_reader.ReadLine();
				return;
			}

			// Execute selected program
			_writer.WriteLine(String.Format("=== Executing {0} ... ===", selectedProgramType.Name));
			IRobotoProgram robotoProgram = _robotoProgramFactory.GetRobotoProgram(selectedProgramType);
			robotoProgram.Execute();

			// Show final output
			_writer.WriteLine("=== Execution Complete...Press any key to exit===");
			_reader.ReadLine();
		}
	}
}