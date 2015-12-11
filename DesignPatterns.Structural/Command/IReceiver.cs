using DesignPatterns.Structural.Command.Implementations;

namespace DesignPatterns.Structural.Command
{
	public interface IReceiver
	{
		void Action(SentenceMakerCommand.SentenceCommandName sentenceCommandName, string text);

	}
}