using DesignPatterns;
using System;

namespace DesignPatternConsole
{
	public interface IRobotoProgramFactory
	{
		Type[] GetAvailableRobotoPrograms();
		IRobotoProgram GetRobotoProgram(Type typeToResolve);
	}
}