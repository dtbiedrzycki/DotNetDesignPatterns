namespace DesignPatterns
{
	public interface IThreeDimensionalMovementComponent: ITwoDimensionalMovementComponent
	{
		void MoveUp();
		void MoveDown();
	}
}