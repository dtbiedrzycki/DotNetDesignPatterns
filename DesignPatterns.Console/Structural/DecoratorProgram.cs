using DesignPatterns;
using DesignPatterns.Structural.Decorator;
using DesignPatterns.Structural.Decorator.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Structural
{
	public class DecoratorProgram : IRobotoProgram
	{
		private readonly IWriter _writer;
		private readonly IReader _reader;

		public DecoratorProgram(IWriter writer, IReader reader)
		{
			_writer = writer;
			_reader = reader;
		}

		public void Execute(System.Collections.Generic.IEnumerable<DesignPatterns.Implementations.Roboto> robotos)
		{
			_writer.WriteLine("=== Running the Decorator Program ===");

			IProgramDecorator sayHelloProgramDecorator = new SayHelloDecorator(_writer);
			IProgramDecorator getStatusProgramDecorator = new GetStatusDecorator(_writer);
			IProgramDecorator quitProgramDecorator = new QuitDecorator(_writer, _reader);

			getStatusProgramDecorator.SetProgram(sayHelloProgramDecorator);
			quitProgramDecorator.SetProgram(getStatusProgramDecorator);

			quitProgramDecorator.Execute(robotos);
		}
	}
}