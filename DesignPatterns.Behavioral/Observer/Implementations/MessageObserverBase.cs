namespace DesignPatterns.Behavioral.Observer.Implementations
{
	public abstract class MessageObserverBase : IMessageObserver
	{
		protected IMessageSubject subject;

		protected MessageObserverBase(IMessageSubject subject)
		{
			this.subject = subject;
		}

		public abstract void Update();
	}
}