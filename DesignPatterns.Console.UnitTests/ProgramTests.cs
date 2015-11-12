using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DesignPatternConsole;
using DesignPatternConsole.GetRobotos;
using DesignPatternConsole.Utilities;
using DesignPatterns.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DesignPatterns.Console.UnitTests
{
	[TestClass]
	public class ProgramTests
	{
		private IWindsorContainer _windsorContainer;
		private MockRepository _mockRepository;
		private Mock<IWriter> _writer;
		private Mock<IReader> _reader;
		private Mock<ISingletonGetRobotoMethod> _singletonGetRobotoMethod;
		private Mock<IRobotoProgram> _robotoProgram;

		[TestInitialize]
		public void SetUp()
		{
			// Set up mocks
			_mockRepository = new MockRepository(MockBehavior.Strict);

			// We don't really car about the writer for now, Loose is fine...
			_writer = _mockRepository.Create<IWriter>(MockBehavior.Loose);
			_reader = _mockRepository.Create<IReader>();
			_singletonGetRobotoMethod = _mockRepository.Create<ISingletonGetRobotoMethod>();
			_robotoProgram = _mockRepository.Create<IRobotoProgram>();

			// Set up stubs
			_writer.Setup(x => x.WriteLine(It.IsNotNull<string>()));

			// Set up castle windsor
			_windsorContainer = new WindsorContainer();
			_windsorContainer.Register(Component.For<IWriter>().Instance(_writer.Object));
			_windsorContainer.Register(Component.For<IReader>().Instance(_reader.Object));
			_windsorContainer.Register(Component.For<ISingletonGetRobotoMethod>().Instance(_singletonGetRobotoMethod.Object));
			_windsorContainer.Register(Component.For<IRobotoProgram>().Instance(_robotoProgram.Object));
		}

		[TestMethod]
		public void Execute_Singleton_GoldFlow()
		{
			// Arrange
			Roboto roboto = new Roboto();
			_singletonGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
			_reader.Setup(x => x.ReadLine()).Returns("1");
			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			Program.Execute(_windsorContainer);

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Once);
			_singletonGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

			_mockRepository.VerifyAll();
		}
	}
}
