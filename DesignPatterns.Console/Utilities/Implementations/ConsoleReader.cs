namespace DesignPatternConsole.Utilities.Implementations
{
	internal class ConsoleReader : IReader
	{
		public string ReadLine()
		{
			return System.Console.ReadLine();
		}
	}
}