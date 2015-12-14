using DesignPatterns.Behavioral.ChainOfResponsibility.Implementations;
using DesignPatterns.Utilities;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.Factory.Implementation
{
	public class MessageHandlerFactory : IMessageHandlerFactory
	{
		private readonly IWriter _writer;

		public MessageHandlerFactory(IWriter writer)
		{
			_writer = writer;
		}

		public IMessageHandler GetAllCapsMessageHandler()
		{
			return new AllCapsMessageHandler();
		}

		public IMessageHandler GetRemoveSpecialCharactersMessageHandler()
		{
			return new RemoveSpecialCharactersMessageHandler();
		}

		public IMessageHandler GetSplitOnDelimeterMessageHandler(char delimeter)
		{
			return new SplitOnDelimeterMessageHandler(delimeter);
		}

		public IMessageHandler GetWriteMessageHandler()
		{
			return new WriteMessageHandler(_writer);
		}
	}
}