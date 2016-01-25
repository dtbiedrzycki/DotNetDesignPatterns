namespace DesignPatterns.Behavioral.Observer
{
	/// <summary>
	/// Defines interface for objects that should be notified of changes in a subject
	/// </summary>
	public interface IMessageObserver
	{
		void Update();
	}
}