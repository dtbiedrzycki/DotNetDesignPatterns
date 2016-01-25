using System;
using DesignPatterns.Utilities;

namespace DesignPatterns.Behavioral.Observer.Implementations
{
	public class ReverseRepeaterMessageObserver : MessageObserverBase, IDisposable
	{
		private readonly IWriter _writer;

		public ReverseRepeaterMessageObserver(IMessageSubject subject, IWriter writer) : base(subject)
		{
			_writer = writer;
		}

		public override void Update()
		{
			char[] charState = this.subject.State.ToCharArray();
			Array.Reverse(charState);
			string stringState = new string(charState);

			_writer.WriteLine($"ReverseRepeaterMessageObserver: {stringState}");
		}

		public void Dispose()
		{
		}
	}
}