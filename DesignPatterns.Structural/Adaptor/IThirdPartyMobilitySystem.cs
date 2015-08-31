using System;

namespace DesignPatterns.Structural.Adaptor
{
	public interface IThirdPartyMobilitySystem
	{
		/// <summary>
		/// (x,y,z) coordinates tuple
		/// </summary>
		Tuple<int, int, int> Coordinates { get; }

		/// <summary>
		/// Stops any and all movements
		/// </summary>
		void Stop();

		/// <summary>
		/// Starts forward movement
		/// </summary>
		void BeginMoveForward();

		/// <summary>
		/// Starts backwards movement
		/// </summary>
		void BeginMoveBackward();

		/// <summary>
		/// Starts movement towards the left
		/// </summary>
		void BeginMoveLeft();
		
		/// <summary>
		/// Starts movement towards the right
		/// </summary>
		void BeginMoveRight();
	}
}