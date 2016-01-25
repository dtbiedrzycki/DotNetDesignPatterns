namespace DesignPatterns.Behavioral.Observer
{
	/// <summary>
	/// Stores state and keeps state consistent with that of the Oberservers
	/// </summary>
	public interface IMessageSubject
	{
		void Attach(IMessageObserver observer);
		void Detach(IMessageObserver observer);
		void Notify();
		string State { get; set; }
	}
}