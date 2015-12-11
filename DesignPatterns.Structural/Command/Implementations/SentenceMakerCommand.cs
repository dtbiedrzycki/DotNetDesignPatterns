using System;

namespace DesignPatterns.Structural.Command.Implementations
{
	public class SentenceMakerCommand : ICommand
	{
		private readonly IReceiver _receiver;
		private readonly SentenceCommandName _sentenceCommandName;
		private readonly string _text;

		public SentenceMakerCommand(IReceiver receiver, SentenceCommandName sentenceCommandName , string text)
		{
			_receiver = receiver;
			_sentenceCommandName = sentenceCommandName;
			_text = text;
		}

		public void Execute()
		{
			_receiver.Action(_sentenceCommandName, _text);
		}

		public void UnExecute()
		{
			_receiver.Action(this.GetInverseCommand(_sentenceCommandName), _text);	
		}

		private SentenceCommandName GetInverseCommand(SentenceCommandName sentenceCommandName)
		{
			switch (sentenceCommandName)
			{
				case SentenceCommandName.Add:
					return SentenceCommandName.Remove;
				case SentenceCommandName.Remove:
					return SentenceCommandName.Add;
				case SentenceCommandName.Encrypt:
					return SentenceCommandName.Decrypt;
				case SentenceCommandName.Decrypt:
					return SentenceCommandName.Encrypt;
				default:
					throw new ArgumentException("Invalid command");
			}
		}

		public enum SentenceCommandName
		{
			Add,
			Remove,
			Encrypt,
			Decrypt,
		}
	}
}