using System.Text.RegularExpressions;

namespace DesignPatterns.Structural.ChainOfResponsibility.Implementations
{
	public class RemoveSpecialCharactersMessageHandler : MessageHandlerBase
	{
		public override void HandleMessage(string message)
		{
			if (this.successor != null)
			{
				this.successor.HandleMessage(this.RemoveSpecialCharacters(message));
			}
		}

		// kudos to : http://stackoverflow.com/questions/1120198/most-efficient-way-to-remove-special-characters-from-string
		private string RemoveSpecialCharacters(string str)
		{
			return Regex.Replace(str, "[^a-zA-Z0-9_\\s.]+", "", RegexOptions.Compiled);
		}
	}
}