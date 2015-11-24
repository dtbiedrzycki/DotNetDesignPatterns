using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatterns.Structural.Decorator.Implementations
{
	public class QuitDecorator : DecoratorBase
	{
		private readonly IWriter _writer;
		private readonly IReader _reader;

		public QuitDecorator(IWriter writer, IReader reader)
		{
			_writer = writer;
			_reader = reader;
		}

		public override void Execute(System.Collections.Generic.IEnumerable<Roboto> robotos)
		{
			base.Execute(robotos);

			_writer.WriteLine("Press any key to quit");
			_reader.ReadLine();
		}
	}
}