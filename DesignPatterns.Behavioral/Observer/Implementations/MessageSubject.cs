using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer.Implementations
{
	public class MessageSubject : IMessageSubject
	{
		private readonly IList<IMessageObserver> _observers;

		public MessageSubject()
		{
			_observers = new List<IMessageObserver>();
		}

		public void Attach(IMessageObserver observer)
		{
			_observers.Add(observer);
		}

		public void Detach(IMessageObserver observer)
		{
			_observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (IMessageObserver observer in _observers)
			{
				observer.Update();
			}
		}

		public string State { get; set; }
	}
}