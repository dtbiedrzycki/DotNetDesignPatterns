using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using DesignPatterns;
using DesignPatterns.Behavioral.ChainOfResponsibility;
using DesignPatterns.Behavioral.ChainOfResponsibility.Factory;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Examples.Behavioral
{
	public class ChainOfResponsibilityProgram : IRobotoProgram
	{
		private readonly IMessageHandlerFactory _messageHandlerFactory;
		private readonly IWriter _writer;
		private readonly IReader _reader;

		public ChainOfResponsibilityProgram(IMessageHandlerFactory messageHandlerFactory, IWriter writer, IReader reader)
		{
			_messageHandlerFactory = messageHandlerFactory;
			_writer = writer;
			_reader = reader;
		}

		public void Execute()
		{
			_writer.WriteLine("=== Running the Chain of Responsibility Program ===");
			_writer.WriteLine("Please enter your message:");
			string message = _reader.ReadLine();
			
			var messageHandlers = new List<Tuple<string, IMessageHandler>>();
			CommandLineCommand[] commands = GetCommands();
			IDictionary<string, CommandLineCommand> commandLookUp = commands.ToDictionary(x => x.CommandText, x => x);

			// REPL loop
			bool loop = true;
			while (loop)
			{
				if (messageHandlers.Any())
				{
					_writer.WriteLine(Environment.NewLine + "Current Program:");
					this.PrintProgram(messageHandlers.Select(x => x.Item1));
				}

				_writer.WriteLine(Environment.NewLine + "Please select one of the following commands:");
				commands.ForEach(x => _writer.WriteLine(String.Format("{0} -> {1}", x.CommandText, x.CommandDescription)));
				_writer.WriteLine("");
				string commandInput = _reader.ReadLine();

				CommandLineCommand currentCommand;
				if (commandLookUp.TryGetValue(commandInput, out currentCommand))
				{
					IMessageHandler newHandler = currentCommand.CommandFunction();
					if (newHandler == null)
					{
						loop = false;
					}
					else
					{
						messageHandlers.Add(new Tuple<string, IMessageHandler>(currentCommand.CommandText, newHandler));
					}
				}
			}

			// The last handler will always be a message handler
			messageHandlers.Add(new Tuple<string, IMessageHandler>("write",_messageHandlerFactory.GetWriteMessageHandler()));

			// Set up handlers
			for (int i = 1; i < messageHandlers.Count; i++)
			{
				messageHandlers[i-1].Item2.SetSuccessor(messageHandlers[i].Item2);
			}

			// Execute
			_writer.WriteLine(Environment.NewLine + "=== Original Input ===");
			_writer.WriteLine(message);
			_writer.WriteLine(Environment.NewLine + "=== Final Program ===");
			this.PrintProgram(messageHandlers.Select(x => x.Item1));
			_writer.WriteLine(Environment.NewLine + "=== Final Output ===");

			messageHandlers[0].Item2.HandleMessage(message);
		}

		private void PrintProgram(IEnumerable<string> commands)
		{
			_writer.WriteLine(String.Format("[{0}]", String.Join(", ", commands)));
		}

		private CommandLineCommand[] GetCommands()
		{
			return new[]
			{
				new CommandLineCommand()
				{
					CommandText = "r",
					CommandDescription = "run",
					CommandFunction = () => null
				},
				new CommandLineCommand()
				{
					CommandText = "allCaps",
					CommandDescription = "Convert all characters to Upper variant",
					CommandFunction = () => _messageHandlerFactory.GetAllCapsMessageHandler()
				},
				new CommandLineCommand()
				{
					CommandText = "rmSpecial",
					CommandDescription = "Remove all special characters",
					CommandFunction = () => _messageHandlerFactory.GetRemoveSpecialCharactersMessageHandler()
				},
				new CommandLineCommand()
				{
					CommandText = "split",
					CommandDescription = "split on character",
					CommandFunction = () =>
					{
						string input = String.Empty;
						bool loop = true;
						while (loop)
						{
							_writer.WriteLine("Choose delimeter character:");
							input = _reader.ReadLine();
							if (!string.IsNullOrEmpty(input) && input.Length == 1)
							{
								loop = false;
							}
						}

						return _messageHandlerFactory.GetSplitOnDelimeterMessageHandler(input[0]);
					}
				}
			};
		}

		private class CommandLineCommand
		{
			public string CommandText { get; set; }
			public string CommandDescription { get; set; }
			public Func<IMessageHandler> CommandFunction { get; set; }
		}
	}
}