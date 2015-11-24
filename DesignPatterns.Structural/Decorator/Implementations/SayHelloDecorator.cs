using System.Collections.Generic;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatterns.Structural.Decorator.Implementations
{
	public class SayHelloDecorator : DecoratorBase
	{
		private readonly IWriter _writer;

		public SayHelloDecorator(IWriter writer)
		{
			_writer = writer;
		}

		public override void Execute(IEnumerable<Roboto> robotos)
		{
			base.Execute(robotos);

			_writer.WriteLine("Hello world!");
		}
	}
}