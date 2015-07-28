namespace DesignPatterns.Implementations
{
	public class BipedalMobilitySystem : IMobilitySystem
	{
		private const int TREAD_WATTS = 20;
		private readonly Coordinates _coordinates;
		private readonly IMotor _motor;

		public BipedalMobilitySystem(IMotor motor)
		{
			_motor = motor;
			_coordinates = new Coordinates {X = 0, Y = 0, Z = 0};
		}

		public Coordinates CurrentCoordinates
		{
			get { return _coordinates; }
		}

		public void MoveForward()
		{
			if (_motor.Activate(TREAD_WATTS))
			{
				_coordinates.Y++;
			}
		}

		public void MoveBackward()
		{
			if (_motor.Activate(TREAD_WATTS))
			{
				_coordinates.Y--;
			}
		}

		public void MoveLeft()
		{
			if (_motor.Activate(TREAD_WATTS))
			{
				_coordinates.X--;
			}
		}

		public void MoveRight()
		{
			if (_motor.Activate(TREAD_WATTS))
			{
				_coordinates.X++;
			}
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}