namespace DesignPatterns.Structural.Decorator
{
	/// <summary>
	/// The decorator pattern allows us to dynamically add responsibilities to our program
	/// </summary>
	public interface IProgramDecorator : IRobotoProgram
	{
		void SetProgram(IRobotoProgram program);
	}
}