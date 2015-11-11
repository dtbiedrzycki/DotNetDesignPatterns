using BuilderPatterns.Builder;
using BuilderPatterns.Builder.Implementations;
using Castle.MicroKernel.Registration;
using DesignPatternConsole.GetRobotos;
using DesignPatternConsole.GetRobotos.Implementations;
using DesignPatternConsole.Programs;
using DesignPatternConsole.Utilities;
using DesignPatternConsole.Utilities.Implementations;

namespace DesignPatternConsole.IoC
{
	internal class WindsorInstaller : IWindsorInstaller
	{

		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			// Creational
			container.Register(Component.For<IRobotoFactory>().ImplementedBy<RobotoFactory>().LifestyleTransient());

			// Utilities
			container.Register(Component.For<IWriter>().ImplementedBy<ConsoleWriter>().LifestyleSingleton());
			container.Register(Component.For<IReader>().ImplementedBy<ConsoleReader>().LifestyleSingleton());

			// GetRobotos
			container.Register(Component.For<IFactoryGetRobotoMethod>()
										.ImplementedBy<FactoryGetRobotoMethod>()
										.DynamicParameters((kernel, parameters) => parameters["dateTime"] = System.DateTime.Now)
										.LifestyleTransient());

			container.Register(Component.For<ISingletonGetRobotoMethod>().ImplementedBy<SingletonGetRobotoMethod>().LifestyleTransient());

			// Programs
			container.Register(Component.For<IRobotoProgram>().ImplementedBy<GetStatusProgram>().LifestyleTransient());
		}
	}
}