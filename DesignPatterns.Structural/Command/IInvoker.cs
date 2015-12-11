using DesignPatterns.Structural.Command.Implementations;

namespace DesignPatterns.Structural.Command
{
	public interface IInvoker
	{
		void Do(SentenceMakerCommand.SentenceCommandName commandName, string commandParams);
		void Undo();
	}
}