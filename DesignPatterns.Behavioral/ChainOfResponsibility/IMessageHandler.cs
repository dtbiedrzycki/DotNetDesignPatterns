namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
	/// <summary>
	/// A behavioral pattern that passes along a request down a chain of
	/// objects that can choose to handle it
	/// </summary>
	public interface IMessageHandler
	{
		void HandleMessage(string message);
		void SetSuccessor(IMessageHandler successor);
	}
}