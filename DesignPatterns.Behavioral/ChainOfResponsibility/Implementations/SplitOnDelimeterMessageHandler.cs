
namespace DesignPatterns.Behavioral.ChainOfResponsibility.Implementations
{
	public class SplitOnDelimeterMessageHandler : MessageHandlerBase
	{
		private readonly char _delimeter;

		public SplitOnDelimeterMessageHandler(char delimeter)
		{
			_delimeter = delimeter;
		}

		public override void HandleMessage(string message)
		{
			if (this.successor != null)
			{
				string[] splitMessages = message.Split(_delimeter);
				foreach (string splitMessage in splitMessages)
				{
					this.successor.HandleMessage(splitMessage);
				}
			}
		}
	}
}