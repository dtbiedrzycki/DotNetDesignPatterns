namespace DesignPatterns.Behavioral.ChainOfResponsibility.Implementations
{
	public abstract class MessageHandlerBase : IMessageHandler
	{
		protected IMessageHandler successor;

		public void SetSuccessor(IMessageHandler successor)
		{
			this.successor = successor;
		}

		public abstract void HandleMessage(string message);
	}
}