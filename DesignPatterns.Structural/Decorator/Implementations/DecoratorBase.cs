using DesignPatterns.Implementations;

namespace DesignPatterns.Structural.Decorator.Implementations
{
	public abstract class DecoratorBase : IProgramDecorator
	{
		protected IRobotoProgram Program;

		public void SetProgram(IRobotoProgram program)
		{
			Program = program;
		}

		public virtual void Execute()
		{
			if (Program != null)
			{
				Program.Execute();
			}
		}
	}
}