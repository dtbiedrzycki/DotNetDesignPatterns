namespace DesignPatterns.Behavioral.Observer
{
	public interface IMessageSubject
	{
		void Attach(IMessageObserver observer);
		void Detach(IMessageObserver observer);
		void Notify();
		string State { get; set; }
	}
}