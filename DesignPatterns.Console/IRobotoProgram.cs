using System.Collections.Generic;
using DesignPatterns.Implementations;

namespace DesignPatternConsole
{
	internal interface IRobotoProgram
	{
		void Execute(IEnumerable<Roboto> robotos);
	}
}