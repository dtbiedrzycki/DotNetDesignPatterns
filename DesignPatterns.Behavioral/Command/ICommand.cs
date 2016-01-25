namespace DesignPatterns.Behavioral.Command
{
	/// <summary>
	/// Defines an interface for executing a request
	/// </summary>
	public interface ICommand
	{
		void Execute();
		void UnExecute();
	}
}