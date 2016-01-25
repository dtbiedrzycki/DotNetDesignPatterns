using DesignPatterns.Behavioral.Command.Implementations;

namespace DesignPatterns.Behavioral.Command
{
	/// <summary>
	/// Recieves a command and performs necessary operations
	/// </summary>
	public interface IReceiver
	{
		void Action(SentenceMakerCommand.SentenceCommandName sentenceCommandName, string parameter);
	}
}