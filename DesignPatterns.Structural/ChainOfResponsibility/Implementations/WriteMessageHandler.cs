using DesignPatterns.Utilities;

namespace DesignPatterns.Structural.ChainOfResponsibility.Implementations
{
	public class WriteMessageHandler : MessageHandlerBase
	{
		private readonly IWriter _writer;

		public WriteMessageHandler(IWriter writer)
		{
			_writer = writer;
		}

		public override void HandleMessage(string message)
		{
			_writer.WriteLine(message);
			if (this.successor != null)
			{
				this.successor.HandleMessage(message);
			}
		}
	}
}