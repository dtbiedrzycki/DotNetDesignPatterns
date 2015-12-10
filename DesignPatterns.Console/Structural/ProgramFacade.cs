using System;
using DesignPatternConsole.Creational;
using DesignPatterns;
using DesignPatterns.Implementations;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Structural
{
	internal class ProgramFacade : IProgramFacade
	{
		private readonly IWriter _writer;
		private readonly IReader _reader;
		private readonly ISingletonGetRobotoMethod _singletonGetRobotoMethod;
		private readonly IFactoryGetRobotoMethod _factoryGetRobotoMethod;
		private readonly IBuilderGetRobotMethod _builderGerRobotMethod;
		private readonly IPrototypeGetRobotoMethod _prototypeGetRobotoMethod;
		private readonly IRobotoProgram _decoratorProgram;
		private readonly IRobotoProgram _repositoryProgram;

		public ProgramFacade(
			IWriter writer,
			IReader reader,
			ISingletonGetRobotoMethod singletonGetRobotoMethod,
			IFactoryGetRobotoMethod factoryGetRobotoMethod,
			IBuilderGetRobotMethod builderGerRobotMethod,
			IPrototypeGetRobotoMethod prototypeGetRobotoMethod,
			IRobotoProgram decoratorProgram,
			IRobotoProgram repositoryProgram)
		{
			_writer = writer;
			_reader = reader;
			_singletonGetRobotoMethod = singletonGetRobotoMethod;
			_factoryGetRobotoMethod = factoryGetRobotoMethod;
			_builderGerRobotMethod = builderGerRobotMethod;
			_prototypeGetRobotoMethod = prototypeGetRobotoMethod;
			_decoratorProgram = decoratorProgram;
			_repositoryProgram = repositoryProgram;
		}


		public void Execute()
		{
			// Get user input for creation method
			_writer.WriteLine("===== WELCOME TO ROBOTO-CON 2000! =====");
			_writer.WriteLine("Please select a roboto creation method");
			_writer.WriteLine("1: Singleton\t2: Factory\t3: Builder\t4: Prototype");

			string input = _reader.ReadLine();
			int choice = Convert.ToInt32(input);

			IGetRobotoMethod getRobotoMethod;
			switch (choice)
			{
				case 1:
					getRobotoMethod = _singletonGetRobotoMethod;
					break;

				case 2:
					getRobotoMethod = _factoryGetRobotoMethod;
					break;

				case 3:
					getRobotoMethod = _builderGerRobotMethod;
					break;

				case 4:
					getRobotoMethod = _prototypeGetRobotoMethod;
					break;

				default:
					_writer.WriteLine("Invalid input...game over");
					return;
			}

			Roboto roboto = getRobotoMethod.GetRoboto();

			// Get user input for program selection
			_writer.WriteLine("Please select a program to run");
			_writer.WriteLine("1: DecoratorGetStatus\t2: Repository");

			input = _reader.ReadLine();
			choice = Convert.ToInt32(input);

			IRobotoProgram robotoProgram;

			switch (choice)
			{
				case 1:
					robotoProgram = _decoratorProgram;
					break;

				case 2:
					robotoProgram = _repositoryProgram;
					break;

				default:
					_writer.WriteLine("Invalid input...game over");
					return;
			}

			robotoProgram.Execute(new [] { roboto } );
		}
	}
}