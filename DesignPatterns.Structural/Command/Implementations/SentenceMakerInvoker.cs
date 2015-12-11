using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Structural.Command.Implementations
{
	public class SentenceMakerInvoker : IInvoker
	{
		private readonly IReceiver _receiver;
		private readonly List<ICommand> _commands;

		public SentenceMakerInvoker(IReceiver receiver)
		{
			_receiver = receiver;
			_commands = new List<ICommand>();
		}

		public void Do(SentenceMakerCommand.SentenceCommandName commandName, string commandParams)
		{
			// TODO: factory here
			ICommand newCommand = new SentenceMakerCommand(this._receiver, commandName, commandParams);
			newCommand.Execute();
			_commands.Add(newCommand);
		}

		public void Undo()
		{
			ICommand previousCommand = _commands.LastOrDefault();
			if (previousCommand != null)
			{
				previousCommand.UnExecute();
				_commands.RemoveAt(_commands.Count - 1);
			}
		}
	}
}