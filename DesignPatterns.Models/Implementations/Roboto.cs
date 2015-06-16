using System.Collections.Generic;

namespace DesignPatterns.Implementations
{
	public class Roboto
	{
		public IEnumerable<IArm> Arms { get; set; }
		public IEnumerable<IMobilitySystem> MobilitySystems { get; set; }
		public IEnumerable<IWeaponSystem> WeaponSystems { get; set; }
	}
}
