using System;
using BuilderPatterns.AbstractFactory;
using BuilderPatterns.AbstractFactory.Implementations;
using BuilderPatterns.Builder;
using BuilderPatterns.Builder.Implementations;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DesignPatterns.Behavioral.ChainOfResponsibility.Factory;
using DesignPatterns.Behavioral.ChainOfResponsibility.Factory.Implementation;
using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.Command.Implementations;
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
			container.Register(
				Component.For<IWindsorContainer>().Instance(container)
					.Named("windsorContainer"));

			// This allows us to specify which implementation by the parameter name
			container.Register(
				Component.For<IRobotoProgramFactory>().ImplementedBy<RobotoProgramFactory>().LifestyleTransient()
					.DependsOn(Dependency.OnComponent("windsorContainer", "windsorContainer")));

			container.Register(Component.For<IProgramFacade>().ImplementedBy<ProgramFacade>().LifestyleTransient());

			// Creational
			container.Register(Component.For<IRobotoFactory>().ImplementedBy<RobotoFactory>().LifestyleTransient());
			container.Register(Component.For<IRobotoBuilder>().ImplementedBy<RobotoBuilder>().LifestyleTransient());

			// Utilities
			container.Register(Component.For<IWriter>().ImplementedBy<ConsoleWriter>().LifestyleSingleton());
			container.Register(Component.For<IReader>().ImplementedBy<ConsoleReader>().LifestyleSingleton());
			container.Register(Component.For<ICypher>().ImplementedBy<Cypher>().LifestyleSingleton());

			// Structural
			container.Register(Component.For<IRobotoRepository>().ImplementedBy<RobotoFileRepository>().LifestyleTransient());
			container.Register(Component.For<IMessageHandlerFactory>().ImplementedBy<MessageHandlerFactory>().LifestyleTransient());
			container.Register(Component.For<IInvoker>().ImplementedBy<SentenceMakerInvoker>().LifestyleTransient());
			container.Register(Component.For<IReceiver>().ImplementedBy<SentenceMakerReceiver>().LifestyleTransient());
		}
	}
}