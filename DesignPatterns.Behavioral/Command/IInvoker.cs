using DesignPatterns.Behavioral.Command.Implementations;

namespace DesignPatterns.Behavioral.Command
{
	public interface IInvoker
	{
		void Do(SentenceMakerCommand.SentenceCommandName commandName, string commandParams);
		void Undo();
	}
}