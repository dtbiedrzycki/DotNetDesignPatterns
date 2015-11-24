namespace DesignPatterns.Utilities.Implementations
{
	public class ConsoleWriter : IWriter
	{

		public void WriteLine(string line)
		{
			System.Console.WriteLine(line);
		}
	}
}