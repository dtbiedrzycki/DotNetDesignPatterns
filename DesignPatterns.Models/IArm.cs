namespace DesignPatterns
{
	public interface IArm : IThreeDimensionalMovementComponent
	{
		void Open();
		void Close();
	}
}