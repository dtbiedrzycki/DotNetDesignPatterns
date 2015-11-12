using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Implementations;

namespace DesignPatternConsole.Programs
{
	public class GetStatusProgram : IRobotoProgram
	{
		public void Execute(IEnumerable<Roboto> robotos)
		{
			// Get the robot's status
			string status = String.Join(System.Environment.NewLine, robotos.Select(x => x.GetStatus()));

			// Print out the robots' status
			Console.WriteLine(status);
			Console.WriteLine("Press any key to quit");
			Console.Read();
		}
	}
}