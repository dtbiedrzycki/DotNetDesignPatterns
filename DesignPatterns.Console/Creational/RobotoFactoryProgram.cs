﻿using System;
using BuilderPatterns.AbstractFactory;
using DesignPatterns;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Creational
{
	public class RobotoFactoryProgram : IRobotoProgram
	{
		private readonly IRobotoFactory _robotoFactory;
		private readonly IWriter _writer;
		private readonly DateTime _dateTime;

		public RobotoFactoryProgram(IRobotoFactory robotoFactory, IWriter writer, DateTime dateTime)
		{
			_robotoFactory = robotoFactory;
			_writer = writer;
			_dateTime = dateTime;
		}

		public void Execute()
		{
			Roboto roboto = _dateTime.TimeOfDay.Seconds % 2 == 0
				? _robotoFactory.CreateHumanoidRoboto()
				: _robotoFactory.CreateRollingRoboto();

			_writer.WriteLine(roboto.GetStatus());
		}
	}
}