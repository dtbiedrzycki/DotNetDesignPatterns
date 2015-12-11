namespace DesignPatterns.Structural.Command
{
	public interface ICommand
	{
		void Execute();
		void UnExecute();
	}
}