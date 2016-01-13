using System;
using System.Diagnostics;

namespace DesignPatterns.Behavioral.Observer.Implementations
{
	public class RepeaterMessageObserver : MessageObserverBase, IDisposable
	{
		public RepeaterMessageObserver(IMessageSubject subject) : base(subject)
		{
		}

		public override void Update()
		{
			var startInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "echo " + this.subject.State,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = false
			};


			var process = Process.Start(startInfo);
			// TODO: This hangs forever and no new window appears
			process.WaitForExit();
		}

		public void Dispose()
		{
		}
	}
}