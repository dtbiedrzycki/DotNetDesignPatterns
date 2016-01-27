using DesignPatterns;
using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.Command.Implementations;
using DesignPatterns.Utilities;
using System;

namespace DesignPatternConsole.Examples.Behavioral
{
	public class CommandProgram : IRobotoProgram
	{
		private readonly IInvoker _invoker;
		private readonly IWriter _writer;
		private readonly IReader _reader;

		public CommandProgram(IInvoker invoker, IWriter writer, IReader reader)
		{
			_invoker = invoker;
			_writer = writer;
			_reader = reader;
		}

		public void Execute()
		{
			_writer.WriteLine("=== Running the Command Program ===");

			string input = String.Empty;
			const string quitCommand = "q";
			const string addCommand = "a";
			const string encryptCommand = "e";
			const string removeSpecialCharacters = "rsc";
			const string undoCommand = "z";

			while (input != quitCommand)
			{
				_writer.WriteLine("=== Please Select one or the following commands ===");
				_writer.WriteLine(quitCommand + " -> quit");
				_writer.WriteLine(addCommand + " [sentence/words/characters to add] -> add to sentence");
				_writer.WriteLine(encryptCommand + " -> encrypt sentence");
				_writer.WriteLine(removeSpecialCharacters + " -> remove special characters");
				_writer.WriteLine(undoCommand + " -> undo");
				_writer.WriteLine("");

				input = _reader.ReadLine();
				int firstWSIndex = input.IndexOf(" ", StringComparison.Ordinal);
				string parameter = String.Empty;
				if (firstWSIndex != -1)
				{
					int charactersToSkip = firstWSIndex + 1;
					parameter = input.Substring(charactersToSkip, input.Length - charactersToSkip);
					input = input.Substring(0, firstWSIndex);
				}
				
				switch (input)
				{
					case addCommand: 
						_invoker.Do(SentenceMakerCommand.SentenceCommandName.Add, parameter);
						break;
					case encryptCommand:
						_invoker.Do(SentenceMakerCommand.SentenceCommandName.Encrypt, null);
						break;
					case undoCommand:
						_invoker.Undo();
						break;
					case removeSpecialCharacters:
						_invoker.Do(SentenceMakerCommand.SentenceCommandName.RemoveSpecialCharacters, null);
						break;
					default:
						break;
				}
			}
		}
	}
}