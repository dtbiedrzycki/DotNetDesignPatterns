using System;
using BuilderPatterns.Builder;

namespace DesignPatternConsole.GetRobotos.Implementations
{
	internal class BuilderGetRobotoMethod : IBuilderGetRobotMethod
	{
		private readonly IRobotoBuilder _robotoBuilder;
		private readonly DateTime _dateTime;

		public BuilderGetRobotoMethod(IRobotoBuilder robotoBuilder, DateTime dateTime)
		{
			_robotoBuilder = robotoBuilder;
			_dateTime = dateTime;
		}

		public DesignPatterns.Implementations.Roboto GetRoboto()
		{
			_robotoBuilder.CreateNewRoboto();

			int armCount = _dateTime.TimeOfDay.Seconds % 5;

			for (int i = 0; i < armCount; i++)
			{
				_robotoBuilder.AddArm();
			}

			_robotoBuilder.AddMobilitySystem();

			return _robotoBuilder.GetRoboto();
		}
	}
}