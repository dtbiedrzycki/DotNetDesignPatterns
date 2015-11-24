namespace DesignPatterns.Utilities.Implementations
{
	public class ConsoleReader : IReader
	{
		public string ReadLine()
		{
			return System.Console.ReadLine();
		}
	}
}