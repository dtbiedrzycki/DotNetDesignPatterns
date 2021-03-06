﻿using DesignPatterns;
using DesignPatterns.Implementations;
using System;
using System.Collections.Generic;

namespace BuilderPatterns.Builder.Implementations
{
	public class RobotoPrototypeBuilder : IRobotoBuilder
	{
		private readonly IArm _arm;
		private readonly Roboto _baseRoboto;
		private readonly IMobilitySystem _mobilitySystem;
		private Roboto _currentRoboto;

		public RobotoPrototypeBuilder(Roboto baseRoboto, IArm arm, IMobilitySystem mobilitySystem)
		{
			_baseRoboto = baseRoboto;
			_arm = arm;
			_mobilitySystem = mobilitySystem;
		}

		public RobotoPrototypeBuilder(IArm arm, IMobilitySystem mobilitySystem)
			: this(new Roboto(), arm, mobilitySystem)
		{
		}

		public void CreateNewRoboto()
		{
			_currentRoboto = _baseRoboto.Clone() as Roboto;
		}

		public void AddArm()
		{
			if (_currentRoboto != null)
			{
				if (_currentRoboto.Arms == null)
				{
					_currentRoboto.Arms = new List<IArm> {_arm.Clone() as IArm};
				}
				else
				{
					_currentRoboto.Arms.Add(_arm.Clone() as IArm);
				}
			}
		}

		public void AddMobilitySystem()
		{
			if (_currentRoboto != null)
			{
				_currentRoboto.MobilitySystem = _mobilitySystem.Clone() as IMobilitySystem;
			}
		}

		public Roboto GetRoboto()
		{
			Roboto newRoboto = _currentRoboto.Clone() as Roboto;
			if (newRoboto != null)
			{
				newRoboto.Id = Guid.NewGuid();
				newRoboto.Name = "Robo de Prototype";
			}

			return newRoboto;
		}
	}
}