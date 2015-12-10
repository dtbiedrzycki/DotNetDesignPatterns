namespace DesignPatterns.Structural.ChainOfResponsibility
{
	public interface IMessageHandler
	{
		void HandleMessage(string message);
		void SetSuccessor(IMessageHandler successor);
	}
}