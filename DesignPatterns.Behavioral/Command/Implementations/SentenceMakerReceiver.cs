using DesignPatterns.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesignPatterns.Behavioral.Command.Implementations
{
	public class SentenceMakerReceiver : IReceiver
	{
		private readonly ICypher _cypher;
		private readonly IWriter _writer;
		private string _currentText = String.Empty;
		private readonly string _key;
		private readonly Stack<string> _checkPoints;

		public SentenceMakerReceiver(ICypher cypher, IWriter writer)
		{
			_cypher = cypher;
			_writer = writer;

			_checkPoints = new Stack<string>();
			_key = Guid.NewGuid().ToString();
		}

		/// <summary>
		/// This is the only method called by the ICommand implementations.
		/// NOTE: There are a number of other ways to implement the Receiver class
		/// 1. The command classes call the methods on the Reciever directly 
		/// (i.e. command would call ExecuteAdd directly instead of allowing the Receiver to decide)
		/// This would require a different class for each ICommand implementation
		/// 2. The Action method could take in an Action closure, giving all functional implementation to the Command
		/// </summary>
		/// <param name="sentenceCommandName"></param>
		/// <param name="parameter"></param>
		public void Action(SentenceMakerCommand.SentenceCommandName sentenceCommandName, string parameter)
		{
			switch (sentenceCommandName)
			{
				case SentenceMakerCommand.SentenceCommandName.Add:
					this.ExecuteAdd(parameter);
					break;
				case SentenceMakerCommand.SentenceCommandName.Remove:
					this.ExecuteRemove(parameter);
					break;
				case SentenceMakerCommand.SentenceCommandName.Encrypt:
					this.ExecuteEncrypt();
					break;
				case SentenceMakerCommand.SentenceCommandName.Decrypt:
					this.ExecuteDecrypt();
					break;
				case SentenceMakerCommand.SentenceCommandName.RemoveSpecialCharacters:
					this.ExecuteRemoveSpecialCharacters();
					break;
				case SentenceMakerCommand.SentenceCommandName.RevertRemoveSpecialCharacters:
					this.RevertToPreviousCheckpoint();
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

		/// <summary>
		/// This is an example of a command that requires some sort of state in order to be reversed
		/// </summary>
		private void ExecuteRemoveSpecialCharacters()
		{
			string filteredText = Regex.Replace(_currentText, "[^a-zA-Z0-9_\\s.]+", "", RegexOptions.Compiled);
			_checkPoints.Push(_currentText);
			_currentText = filteredText;
		}

		private void RevertToPreviousCheckpoint()
		{
			if (_checkPoints.Any())
			{
				_currentText = _checkPoints.Pop();
			}
		}
	}
}