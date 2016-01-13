using System.Collections.Generic;
using DesignPatterns;
using DesignPatterns.Behavioral.Observer;
using DesignPatterns.Behavioral.Observer.Implementations;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatternConsole.Behavioral
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
			IMessageObserver observer = new RepeaterMessageObserver(subject);

			subject.Attach(observer);

			subject.State = "Hello world!";

			subject.Notify();
			subject.Notify();
			subject.Notify();

			_reader.ReadLine();
		}
	}
}