using System;
using System.Diagnostics;
using DesignPatterns.Utilities;

namespace DesignPatterns.Behavioral.Observer.Implementations
{
	public class RepeaterMessageObserver : MessageObserverBase, IDisposable
	{
		private readonly IWriter _writer;

		public RepeaterMessageObserver(IMessageSubject subject, IWriter writer) : base(subject)
		{
			_writer = writer;
		}

		public override void Update()
		{
			_writer.WriteLine($"RepeaterMessageObserver: {this.subject.State}");
		}

		public void Dispose()
		{
		}
	}
}