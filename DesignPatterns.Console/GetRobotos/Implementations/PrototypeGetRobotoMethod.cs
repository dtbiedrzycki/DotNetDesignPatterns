using System;
using BuilderPatterns.Builder;
using BuilderPatterns.Builder.Implementations;

namespace DesignPatternConsole.GetRobotos.Implementations
{
	internal class PrototypeGetRobotoMethod : FactoryGetRobotoMethod, IPrototypeGetRobotoMethod
	{
		/// <summary>
		/// Creates a PrototypeGetRobotoMethod instance
		/// 
		/// -- Note, this works the same as the FactoryGetRobotoMethod,
		/// however, the prototypes for the humanoid and rolling robotos are flipping
		/// i.e. a requesting a humanoid roboto returns a rolling roboto and visa versa
		/// </summary>
		/// <param name="robotoFactory">A roboto factory to generate robotos</param>
		/// <param name="dateTime">A date time</param>
		public PrototypeGetRobotoMethod(IRobotoFactory robotoFactory, DateTime dateTime)
			: base(new RobotoPrototype(robotoFactory.CreateHumanoidRoboto(), robotoFactory.CreateHumanoidRoboto()), dateTime)
		{
		}
	}
}