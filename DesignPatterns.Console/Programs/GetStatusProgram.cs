using System;
using DesignPatterns.Implementations;

namespace DesignPatternConsole.Programs
{
	public class GetStatusProgram : IRobotoProgram
	{
		private readonly Roboto _roboto;

		public GetStatusProgram(Roboto roboto)
		{
			_roboto = roboto;
		}

		public void Execute()
		{
			// Get the robot's status
			string status = _roboto.GetStatus();

			// Print out the robot's status
			Console.WriteLine(status);
			Console.WriteLine("Press any key to quit");
			Console.Read();
		}
	}
}