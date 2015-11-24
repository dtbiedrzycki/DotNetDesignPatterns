using System;
using Castle.Windsor;
using DesignPatternConsole.Creational;
using DesignPatternConsole.IoC;
using DesignPatterns;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole
{
	internal class Program
	{
		private static IGetRobotoMethod _getRobotoMethod;

		private static void Main(string[] args)
		{
			IWindsorContainer container = new WindsorContainer();
			container.Install(new WindsorInstaller());

			Execute(container);
		}

		internal static void Execute(IWindsorContainer container)
		{
			// Get user input for creation method
			IWriter writer = container.Resolve<IWriter>();
			writer.WriteLine("===== WELCOME TO ROBOTO-CON 2000! =====");
			writer.WriteLine("Please select a roboto creation method");
			writer.WriteLine("1: Singleton\t2: Factory\t3: Builder\t4: Prototype");

			IReader reader = container.Resolve<IReader>();
			string input = reader.ReadLine();
			int choice = Convert.ToInt32(input);

			switch (choice)
			{
				case 1:
					_getRobotoMethod = container.Resolve<ISingletonGetRobotoMethod>();
					break;

				case 2:
					_getRobotoMethod = container.Resolve<IFactoryGetRobotoMethod>();
					break;

				case 3:
					_getRobotoMethod = container.Resolve<IBuilderGetRobotMethod>();
					break;

				case 4:
					_getRobotoMethod = container.Resolve<IPrototypeGetRobotoMethod>();
					break;

				default:
					throw new Exception("Invalid input...game over.");
			}

			Roboto roboto = _getRobotoMethod.GetRoboto();

			// Get user input for program selection
			writer.WriteLine("Please select a program to run");
			writer.WriteLine("1: DecoratorGetStatus");

			input = reader.ReadLine();
			choice = Convert.ToInt32(input);

			IRobotoProgram robotoProgram;

			switch (choice)
			{
				case 1:
					robotoProgram = container.Resolve<IRobotoProgram>();
					break;

				default:
					throw new Exception("Invalid input...game over.");
			}

			robotoProgram.Execute(new [] { roboto } );
		}
	}
}