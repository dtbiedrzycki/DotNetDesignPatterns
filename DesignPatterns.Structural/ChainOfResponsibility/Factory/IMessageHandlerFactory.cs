namespace DesignPatterns.Structural.ChainOfResponsibility.Factory
{
	/// <summary>
	/// Note that this component is not part of the chain of responsibility design pattern
	/// It is here just to make our lives easier
	/// </summary>
	public interface IMessageHandlerFactory
	{
		IMessageHandler GetAllCapsMessageHandler();
		IMessageHandler GetRemoveSpecialCharactersMessageHandler();
		IMessageHandler GetSplitOnDelimeterMessageHandler(char delimeter);
		IMessageHandler GetWriteMessageHandler();
	}
}