﻿using BuilderPatterns.AbstractFactory;
using BuilderPatterns.AbstractFactory.Implementations;
using BuilderPatterns.Builder;
using BuilderPatterns.Builder.Implementations;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using DesignPatternConsole.Creational;
using DesignPatternConsole.Creational.Implementations;
using DesignPatternConsole.Structural;
using DesignPatternConsole.Structural.Programs;
using DesignPatterns;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Structural.Repository;
using DesignPatterns.Structural.Repository.Implementation;
using DesignPatterns.Utilities;
using DesignPatterns.Utilities.Implementations;

namespace DesignPatternConsole.IoC
{
	internal class WindsorInstaller : IWindsorInstaller
	{

		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			// Creational
			container.Register(Component.For<IRobotoFactory>().ImplementedBy<RobotoFactory>().LifestyleTransient());
			container.Register(Component.For<IRobotoBuilder>().ImplementedBy<RobotoBuilder>().LifestyleTransient());

			// Utilities
			container.Register(Component.For<IWriter>().ImplementedBy<ConsoleWriter>().LifestyleSingleton());
			container.Register(Component.For<IReader>().ImplementedBy<ConsoleReader>().LifestyleSingleton());

			// GetRobotos
			container.Register(Component.For<IFactoryGetRobotoMethod>()
										.ImplementedBy<FactoryGetRobotoMethod>()
										.DynamicParameters((kernel, parameters) => parameters["dateTime"] = System.DateTime.Now)
										.LifestyleTransient());
			container.Register(Component.For<IBuilderGetRobotMethod>()
										.ImplementedBy<BuilderGetRobotoMethod>()
										.DynamicParameters((kernel, parameters) => parameters["dateTime"] = System.DateTime.Now)
										.LifestyleTransient());
			container.Register(Component.For<IPrototypeGetRobotoMethod>()
										.ImplementedBy<PrototypeGetRobotoMethod>()
										.DynamicParameters((kernel, parameters) => parameters["dateTime"] = System.DateTime.Now)
										.LifestyleTransient());

			container.Register(Component.For<ISingletonGetRobotoMethod>().ImplementedBy<SingletonGetRobotoMethod>().LifestyleTransient());

			// Structural
			container.Register(Component.For<IRobotoRepository>().ImplementedBy<RobotoFileRepository>().LifestyleTransient());

			// Programs
			container.Register(
				Component.For<IRobotoProgram>().ImplementedBy<DecoratorProgram>()
					.LifestyleTransient()
					.Named("decoratorProgram"));

			container.Register(
				Component.For<IRobotoProgram>().ImplementedBy<RepositoryProgram>()
					.LifestyleTransient()
					.Named("repositoryProgram"));

			// This allows us to specify which implementation by the parameter name
			container.Register(
				Component.For<IProgramFacade>().ImplementedBy<ProgramFacade>().LifestyleTransient()
				.DependsOn(Dependency.OnComponent("decoratorProgram", "decoratorProgram"))
				.DependsOn(Dependency.OnComponent("repositoryProgram", "repositoryProgram")));
		}
	}
}