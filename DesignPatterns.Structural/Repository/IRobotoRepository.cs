using System;
using DesignPatterns.Implementations;

namespace DesignPatterns.Structural.Repository
{
	public interface IRobotoRepository
	{
		void Create(Roboto roboto);
		void Retrieve(Guid id);
	}
}