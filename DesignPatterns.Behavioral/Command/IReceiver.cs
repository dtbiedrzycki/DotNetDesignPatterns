using DesignPatterns.Behavioral.Command.Implementations;

namespace DesignPatterns.Behavioral.Command
{
	public interface IReceiver
	{
		void Action(SentenceMakerCommand.SentenceCommandName sentenceCommandName, string text);

	}
}