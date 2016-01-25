using System.Threading;

namespace DesignPatterns.Structural.Adapter
{
	/// <summary>
	/// A structural pattern that adapts or wraps classes to match a specific interface
	/// </summary>
	public class ThirdPartyArmAdapter : IMobilitySystem
	{
		private readonly IThirdPartyMobilitySystem _thirdPartyMobilitySystem;
		
		public ThirdPartyArmAdapter(IThirdPartyMobilitySystem thirdPartyMobilitySystem)
		{
			_thirdPartyMobilitySystem = thirdPartyMobilitySystem;
		}

		public Coordinates CurrentCoordinates
		{
			get
			{
				var coordinates = new Coordinates()
				{
					X = _thirdPartyMobilitySystem.Coordinates.Item1,
					Y = _thirdPartyMobilitySystem.Coordinates.Item2,
					Z = _thirdPartyMobilitySystem.Coordinates.Item3
				};

				return coordinates;
			}
		}

		public void MoveForward()
		{
			int targetY = _thirdPartyMobilitySystem.Coordinates.Item2 + 1;

			_thirdPartyMobilitySystem.BeginMoveForward();

			while (_thirdPartyMobilitySystem.Coordinates.Item2 < targetY)
			{
				Thread.Sleep(1);
			}
			
			_thirdPartyMobilitySystem.Stop();
		}

		public void MoveBackward()
		{
			int targetY = _thirdPartyMobilitySystem.Coordinates.Item2 - 1;

			_thirdPartyMobilitySystem.BeginMoveBackward();

			while (_thirdPartyMobilitySystem.Coordinates.Item2 > targetY)
			{
				Thread.Sleep(1);
			}

			_thirdPartyMobilitySystem.Stop();
		}

		public void MoveLeft()
		{
			int targetX = _thirdPartyMobilitySystem.Coordinates.Item1 - 1;

			_thirdPartyMobilitySystem.BeginMoveLeft();

			while (_thirdPartyMobilitySystem.Coordinates.Item2 > targetX)
			{
				Thread.Sleep(1);
			}

			_thirdPartyMobilitySystem.Stop();
		}

		public void MoveRight()
		{
			int targetX = _thirdPartyMobilitySystem.Coordinates.Item1 + 1;

			_thirdPartyMobilitySystem.BeginMoveLeft();

			while (_thirdPartyMobilitySystem.Coordinates.Item2 < targetX)
			{
				Thread.Sleep(1);
			}

			_thirdPartyMobilitySystem.Stop();
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
