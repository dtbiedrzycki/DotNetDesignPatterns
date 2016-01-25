using Castle.Windsor;
using DesignPatternConsole.IoC;
using DesignPatterns.Structural.Facade;
namespace DesignPatternConsole
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IWindsorContainer container = new WindsorContainer();
			container.Install(new WindsorInstaller());
			IProgramFacade programFacade = container.Resolve<IProgramFacade>();

			Execute(programFacade);
		}

		internal static void Execute(IProgramFacade programFacade)
		{
			programFacade.Execute();
		}
	}
}