using BuilderPatterns.Singleton;
using DesignPatterns;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Examples.Creational
{
	public class SingletonRobotoProgram: IRobotoProgram
	{
		private readonly IWriter _writer;

		public SingletonRobotoProgram(IWriter writer)
		{
			_writer = writer;
		}

		public void Execute()
		{
			Roboto roboto = AlphaRobotoSingleton.Instance();

			_writer.WriteLine(roboto.GetStatus());
		}
	}
}
