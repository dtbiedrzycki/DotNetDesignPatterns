using System.Collections.Generic;
using DesignPatterns.Implementations;

namespace DesignPatterns
{
	public interface IRobotoProgram
	{
		void Execute(IEnumerable<Roboto> robotos);
	}
}