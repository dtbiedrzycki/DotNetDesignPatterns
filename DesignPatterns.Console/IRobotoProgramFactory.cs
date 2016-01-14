using System;
using Castle.Windsor;
using DesignPatterns;

namespace DesignPatternConsole
{
	public interface IRobotoProgramFactory
	{
		Type[] GetAvailableRobotoPrograms();
		IRobotoProgram GetRobotoProgram(Type typeToResolve);
	}
}