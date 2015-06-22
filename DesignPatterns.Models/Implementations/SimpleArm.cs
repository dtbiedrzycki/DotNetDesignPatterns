using System;

namespace DesignPatterns.Implementations
{
	public class SimpleArm : IArm
	{
		private readonly Coordinates _coordinates;
		private readonly IMotor _motor;

		private const int MAX_REACH = 5;

		public SimpleArm(IMotor motor)
		{
			_coordinates = new Coordinates() { X = 0, Y = 0, Z = 0 };
			_motor = motor;
		}

		public Coordinates CurrentCoordinates
		{
			get { return _coordinates; }
		}

		public void MoveForward()
		{
			if (_motor.Activate(1) && Math.Abs(_coordinates.Y) <= MAX_REACH)
			{
				_coordinates.Y++;
			}
		}

		public void MoveBackward()
		{
			if (_motor.Activate(1) && Math.Abs(_coordinates.Y) <= MAX_REACH)
			{
				_coordinates.Y--;
			}
		}

		public void MoveLeft()
		{
			if (_motor.Activate(1) && Math.Abs(_coordinates.X) <= MAX_REACH)
			{
				_coordinates.X--;
			}
		}

		public void MoveRight()
		{
			if (_motor.Activate(1) && Math.Abs(_coordinates.X) <= MAX_REACH)
			{
				_coordinates.X++;
			}
		}

		public void MoveUp()
		{
			if (_motor.Activate(1) && Math.Abs(_coordinates.Z) <= MAX_REACH)
			{
				_coordinates.Z++;
			}
		}

		public void MoveDown()
		{
			if (_motor.Activate(1) && Math.Abs(_coordinates.Z) <= MAX_REACH)
			{
				_coordinates.Z--;
			}
		}

		public void Open()
		{
			throw new System.NotImplementedException();
		}

		public void Close()
		{
			throw new System.NotImplementedException();
		}

	}
}
