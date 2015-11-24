using System;
using BuilderPatterns;
using DesignPatterns.Implementations;

namespace DesignPatternConsole.Creational.Implementations
{
	public class FactoryGetRobotoMethod : IFactoryGetRobotoMethod
	{
		private readonly IRobotoFactory _robotoFactory;
		private readonly DateTime _dateTime;

		public FactoryGetRobotoMethod(IRobotoFactory robotoFactory, DateTime dateTime)
		{
			_robotoFactory = robotoFactory;
			_dateTime = dateTime;
		}

		public DesignPatterns.Implementations.Roboto GetRoboto()
		{
			Roboto roboto = _dateTime.TimeOfDay.Seconds % 2 == 0 
				? _robotoFactory.CreateHumanoidRoboto() 
				: _robotoFactory.CreateRollingRoboto();

			return roboto;
		}
	}
}