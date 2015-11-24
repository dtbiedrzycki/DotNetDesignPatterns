using System;
using System.Linq;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatterns.Structural.Decorator.Implementations
{
	public class GetStatusDecorator : DecoratorBase
	{
		private readonly IWriter _writer;

		public GetStatusDecorator(IWriter writer)
		{
			_writer = writer;
		}

		public override void Execute(System.Collections.Generic.IEnumerable<Roboto> robotos)
		{
			base.Execute(robotos);

			// Get the robot's status
			string status = String.Join(System.Environment.NewLine, robotos.Select(x => x.GetStatus()));

			// Print out the robots' status
			_writer.WriteLine(status);
		}
	}
}