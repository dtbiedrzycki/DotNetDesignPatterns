using System;
using Castle.Windsor;
using DesignPatternConsole.GetRobotos;
using DesignPatternConsole.IoC;
using DesignPatternConsole.Utilities;
using DesignPatterns.Implementations;

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
			// Get user input
			IWriter writer = container.Resolve<IWriter>();
			writer.WriteLine("===== WELCOME TO ROBOTO-CON 2000! =====");
			writer.WriteLine("Please select a roboto creation method");
			writer.WriteLine("1: Singleton\t2: Factory");

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

				default:
					throw new Exception("Invalid input...game over.");
			}

			Roboto roboto = _getRobotoMethod.GetRoboto();

			// TODO: allow user to select program
			IRobotoProgram robotoProgram = container.Resolve<IRobotoProgram>(new {roboto = roboto});

			robotoProgram.Execute();
		}
	}
}