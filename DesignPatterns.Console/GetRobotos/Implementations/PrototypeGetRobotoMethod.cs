using System;
using BuilderPatterns.Builder.Implementations;
using DesignPatterns.Implementations;

namespace DesignPatternConsole.GetRobotos.Implementations
{
	internal class PrototypeGetRobotoMethod : FactoryGetRobotoMethod, IPrototypeGetRobotoMethod
	{
		public PrototypeGetRobotoMethod(Roboto humanoidTemplate, Roboto rollingTemplate, DateTime dateTime)
			: base(new RobotoPrototype(humanoidTemplate, rollingTemplate), dateTime)
		{
		}
	}
}