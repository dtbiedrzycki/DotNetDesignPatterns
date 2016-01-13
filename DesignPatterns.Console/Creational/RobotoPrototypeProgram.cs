using System;
using BuilderPatterns.AbstractFactory;
using BuilderPatterns.Prototype;
using BuilderPatterns.Prototype.Implementations;
using DesignPatterns;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Creational
{
	public class RobotoPrototypeProgram : IRobotoProgram
	{
		private readonly IRobotoFactory _robotoFactory;
		private readonly IWriter _writer;
		private readonly DateTime _dateTime;

		public RobotoPrototypeProgram(IRobotoFactory robotoFactory, IWriter writer, DateTime dateTime)
		{
			_robotoFactory = robotoFactory;
			_writer = writer;
			_dateTime = dateTime;
		}

		public void Execute()
		{
			IRobotoPrototype prototype = new RobotoPrototype(_robotoFactory.CreateHumanoidRoboto(), _robotoFactory.CreateRollingRoboto());

			Roboto roboto = _dateTime.TimeOfDay.Seconds % 2 == 0
				? prototype.CreateHumanoidRoboto()
				: prototype.CreateRollingRoboto();

			_writer.WriteLine(roboto.GetStatus());
		}
	}
}