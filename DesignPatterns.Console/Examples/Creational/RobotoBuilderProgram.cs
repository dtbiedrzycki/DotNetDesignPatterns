using BuilderPatterns.Builder;
using DesignPatterns;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;
using System;

namespace DesignPatternConsole.Examples.Creational
{
	public class RobotoBuilderProgram : IRobotoProgram
	{
		private readonly IRobotoBuilder _robotoBuilder;
		private readonly IWriter _writer;
		private readonly DateTime _dateTime;

		public RobotoBuilderProgram(IRobotoBuilder robotoBuilder, IWriter writer)
		{
			_robotoBuilder = robotoBuilder;
			_writer = writer;
			_dateTime = DateTime.Now;
		}

		public void Execute()
		{
			_robotoBuilder.CreateNewRoboto();

			int armCount = _dateTime.TimeOfDay.Seconds % 5;

			for (int i = 0; i < armCount; i++)
			{
				_robotoBuilder.AddArm();
			}

			_robotoBuilder.AddMobilitySystem();

			Roboto finalRoboto = _robotoBuilder.GetRoboto();

			_writer.WriteLine(finalRoboto.GetStatus());
		}
	}
}