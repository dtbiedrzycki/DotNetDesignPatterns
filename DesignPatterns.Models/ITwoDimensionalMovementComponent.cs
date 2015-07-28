using System;

namespace DesignPatterns
{
	public interface ITwoDimensionalMovementComponent : ICloneable
	{
		void MoveForward();
		void MoveBackward();
		void MoveLeft();
		void MoveRight();
		Coordinates CurrentCoordinates { get; }
	}
}