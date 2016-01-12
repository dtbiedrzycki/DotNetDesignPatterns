using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Behavioral.Command.Implementations
{
	public class SentenceMakerInvoker : IInvoker
	{
		private readonly IReceiver _receiver;
		private readonly Stack<ICommand> _commands;

		public SentenceMakerInvoker(IReceiver receiver)
		{
			_receiver = receiver;
			_commands = new Stack<ICommand>();
		}

		public void Do(SentenceMakerCommand.SentenceCommandName commandName, string commandParams)
		{
			// TODO: factory here
			ICommand newCommand = new SentenceMakerCommand(this._receiver, commandName, commandParams);
			newCommand.Execute();
			_commands.Push(newCommand);
		}

		public void Undo()
		{
			if (_commands.Any())
			{
				ICommand previousCommand = _commands.Pop();
				if (previousCommand != null)
				{
					previousCommand.UnExecute();
				}
			}
		}
	}
}