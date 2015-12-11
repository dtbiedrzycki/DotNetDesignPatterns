using System;
using DesignPatterns.Utilities;

namespace DesignPatterns.Structural.Command.Implementations
{
	public class SentenceMakerReceiver : IReceiver
	{
		private readonly ICypher _cypher;
		private readonly IWriter _writer;
		private string _currentText = String.Empty;
		private const string _key = "SuperSecr3tP4ss";

		public SentenceMakerReceiver(ICypher cypher, IWriter writer)
		{
			_cypher = cypher;
			_writer = writer;
		}

		public void Action(SentenceMakerCommand.SentenceCommandName sentenceCommandName, string text)
		{
			switch (sentenceCommandName)
			{
				case SentenceMakerCommand.SentenceCommandName.Add:
					this.ExecuteAdd(text);
					break;
				case SentenceMakerCommand.SentenceCommandName.Remove:
					this.ExecuteRemove(text);
					break;
				case SentenceMakerCommand.SentenceCommandName.Encrypt:
					this.ExecuteEncrypt();
					break;
				case SentenceMakerCommand.SentenceCommandName.Decrypt:
					this.ExecuteDecrypt();
					break;
				default:
					throw new ArgumentException("Invalid command");
			}

			_writer.WriteLine("Current Sentence: " + _currentText);
		}

		private void ExecuteAdd(string text)
		{
			_currentText += text;
		}
		private void ExecuteRemove(string text)
		{
			int lastIndex = _currentText.LastIndexOf(text, StringComparison.Ordinal);
			string newString = _currentText.Remove(lastIndex, text.Length);

			_currentText = newString;
		}
		private void ExecuteEncrypt()
		{
			string encryptedText = _cypher.Encrypt(_currentText, _key);
			_currentText = encryptedText;
		}
		private void ExecuteDecrypt()
		{
			string decryptedText = _cypher.Decrypt(_currentText, _key);
			_currentText = decryptedText;
		}
	}
}