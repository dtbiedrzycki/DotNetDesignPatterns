using DesignPatterns.Implementations;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Repository
{
	/// <summary>
	/// A structural design pattern that (normally) performs CRUD operations on an object
	/// </summary>
	public interface IRobotoRepository
	{
		void Create(Roboto roboto);
		Roboto Retrieve(Guid id);
		IEnumerable<Roboto> RetrieveAll();
	}
}