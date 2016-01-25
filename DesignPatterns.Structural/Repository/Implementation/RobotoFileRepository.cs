using DesignPatterns.Implementations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatterns.Structural.Repository.Implementation
{
	public class RobotoFileRepository : IRobotoRepository
	{
		private string GetFilePath()
		{
			string fileName = "RobotoDatabase.txt";
			return new Uri( Path.Combine(Directory.GetCurrentDirectory(), fileName)).LocalPath;
		}

		public void Create(Roboto roboto)
		{
			string serializedRoboto = JsonConvert.SerializeObject(new { id = roboto.Id, name = roboto.Name });
			using (System.IO.StreamWriter file = new StreamWriter(this.GetFilePath(), true))
			{
				file.WriteLine(serializedRoboto);
			}
		}
		public void DeleteAll()
		{
			using (File.Create(this.GetFilePath()))
			{
			}
		}


		public Roboto Retrieve(System.Guid id)
		{
			IEnumerable<Roboto> robotos = this.RetrieveAll();
			Roboto foundRoboto = robotos.FirstOrDefault(x => x.Id == id);

			return foundRoboto;
		}

		public IEnumerable<Roboto> RetrieveAll()
		{
			IEnumerable<Roboto> robotos = new List<Roboto>();
			try
			{
				 robotos = System.IO.File.ReadAllLines(this.GetFilePath())
					.Select(x =>
					{
						dynamic robotoInfo = JsonConvert.DeserializeObject(x);
						return new Roboto()
						{
							Id = robotoInfo.id,
							Name = robotoInfo.name
						};
					});
			}
			catch (FileNotFoundException)
			{
				// do nothing, the file hasn't yet been created
			}

			return robotos;
		}
	}
}