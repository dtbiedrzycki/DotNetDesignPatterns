using System;

namespace DesignPatterns
{
	public interface ITwoDimensionalMovementComponent : ICloneable
	{
		Coordinates CurrentCoordinates { get; }
		void MoveForward();
		void MoveBackward();
		void MoveLeft();
		void MoveRight();
	}
}