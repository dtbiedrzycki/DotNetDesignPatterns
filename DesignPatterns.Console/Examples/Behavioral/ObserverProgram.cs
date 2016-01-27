using DesignPatterns;
using DesignPatterns.Behavioral.Observer;
using DesignPatterns.Behavioral.Observer.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Examples.Behavioral
{
	public class ObserverProgram : IRobotoProgram
	{
		private readonly IWriter _writer;

		public ObserverProgram(IWriter writer)
		{
			_writer = writer;
		}

		public void Execute()
		{
			IMessageSubject subject = new MessageSubject();
			this.SetUpObservers(subject);

			subject.State = "Hello world!";
			subject.Notify();

			subject.State = "Just getting the message accross...";
			subject.Notify();
		}

		private void SetUpObservers(IMessageSubject subject)
		{
			IMessageObserver repeaterMessageObserver = new RepeaterMessageObserver(subject, _writer);
			IMessageObserver reverseRepeaterMessageObserver = new ReverseRepeaterMessageObserver(subject, _writer);

			subject.Attach(repeaterMessageObserver);
			subject.Attach(reverseRepeaterMessageObserver);
		}
	}
}