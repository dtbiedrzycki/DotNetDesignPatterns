using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DesignPatterns;
using DesignPatterns.Structural.Decorator;
using System;
using System.Linq;

namespace DesignPatternConsole
{
	public class RobotoProgramFactory : IRobotoProgramFactory
	{
		private readonly IWindsorContainer _windsorContainer;

		public RobotoProgramFactory(IWindsorContainer windsorContainer)
		{
			_windsorContainer = windsorContainer;
		}

		public Type[] GetAvailableRobotoPrograms()
		{
			Type[] assemblies = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => 
					typeof(IRobotoProgram).IsAssignableFrom(p) 
					&& !typeof(IProgramDecorator).IsAssignableFrom(p)
					&& p.Name != "IRobotoProgram").ToArray();

			return assemblies;
		}

		public IRobotoProgram GetRobotoProgram(Type typeToResolve)
		{
			_windsorContainer.Register(Component.For<IRobotoProgram>().ImplementedBy(typeToResolve));

			IRobotoProgram program = _windsorContainer.Resolve<IRobotoProgram>();

			return program;
		}
	}
}