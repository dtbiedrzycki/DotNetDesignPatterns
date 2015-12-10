using System;

namespace DesignPatterns.Structural.ChainOfResponsibility.Implementations
{
	public class AllCapsMessageHandler : MessageHandlerBase
	{
		public override void HandleMessage(string message)
		{
			if (this.successor != null)
			{
				this.successor.HandleMessage(message.ToUpperInvariant());
			}
		}
	}
}