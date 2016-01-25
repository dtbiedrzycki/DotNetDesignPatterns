using DesignPatterns.Behavioral.Command.Implementations;

namespace DesignPatterns.Behavioral.Command
{
	/// <summary>
	/// Asks the command to execute
	/// </summary>
	public interface IInvoker
	{
		void Do(SentenceMakerCommand.SentenceCommandName commandName, string commandParams);
		void Undo();
	}
}