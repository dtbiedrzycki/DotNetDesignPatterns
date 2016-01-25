using DesignPatterns;
using DesignPatterns.Behavioral.Observer;
using DesignPatterns.Behavioral.Observer.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Examples.Behavioral
{
	public class ObserverProgram : IRobotoProgram
	{
		private readonly IWriter _writer;
		private readonly IReader _reader;

		public ObserverProgram(IWriter writer, IReader reader)
		{
			_writer = writer;
			_reader = reader;
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