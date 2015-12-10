using System;
using System.Collections.Generic;
using DesignPatterns.Implementations;

namespace DesignPatterns.Structural.Repository
{
	public interface IRobotoRepository
	{
		void Create(Roboto roboto);
		Roboto Retrieve(Guid id);
		IEnumerable<Roboto> RetrieveAll();
	}
}