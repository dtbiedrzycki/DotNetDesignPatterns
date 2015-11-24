using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DesignPatternConsole;
using DesignPatternConsole.Creational;
using DesignPatterns.Implementations;
using DesignPatterns.Utilities;
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
		private Mock<IFactoryGetRobotoMethod> _factoryGetRobotoMethod;
		private Mock<IBuilderGetRobotMethod> _builderGetRobotoMethod;
		private Mock<IPrototypeGetRobotoMethod> _prototypeGetRobotoMethod;
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
			_factoryGetRobotoMethod = _mockRepository.Create<IFactoryGetRobotoMethod>();
			_builderGetRobotoMethod = _mockRepository.Create<IBuilderGetRobotMethod>();
			_prototypeGetRobotoMethod = _mockRepository.Create<IPrototypeGetRobotoMethod>();
			_robotoProgram = _mockRepository.Create<IRobotoProgram>();

			// Set up stubs
			_writer.Setup(x => x.WriteLine(It.IsNotNull<string>()));

			// Set up castle windsor
			_windsorContainer = new WindsorContainer();
			_windsorContainer.Register(Component.For<IWriter>().Instance(_writer.Object));
			_windsorContainer.Register(Component.For<IReader>().Instance(_reader.Object));
			_windsorContainer.Register(Component.For<ISingletonGetRobotoMethod>().Instance(_singletonGetRobotoMethod.Object));
			_windsorContainer.Register(Component.For<IFactoryGetRobotoMethod>().Instance(_factoryGetRobotoMethod.Object));
			_windsorContainer.Register(Component.For<IBuilderGetRobotMethod>().Instance(_builderGetRobotoMethod.Object));
			_windsorContainer.Register(Component.For<IPrototypeGetRobotoMethod>().Instance(_prototypeGetRobotoMethod.Object));
			_windsorContainer.Register(Component.For<IRobotoProgram>().Instance(_robotoProgram.Object));
		}

		[TestMethod]
		public void Execute_Singleton_GoldFlow()
		{
			// Arrange
			Roboto roboto = new Roboto();
			_reader.Setup(x => x.ReadLine()).Returns("1");
			_singletonGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			Program.Execute(_windsorContainer);

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			_singletonGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

			_mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Execute_FactoryGetRobotoMethod_GoldFlow()
		{
			// Arrange
			Roboto roboto = new Roboto();
			var returnValues = new string[] {"2", "1"};
			int index = 0;
			_reader.Setup(x => x.ReadLine()).Returns(() => returnValues[index++]);
			_factoryGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			Program.Execute(_windsorContainer);

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			_factoryGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

			_mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Execute_BuilderGetRobotoMethod_GoldFlow()
		{
			// Arrange
			Roboto roboto = new Roboto();
			var returnValues = new string[] {"3", "1"};
			int index = 0;
			_reader.Setup(x => x.ReadLine()).Returns(() => returnValues[index++]);
			_builderGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			Program.Execute(_windsorContainer);

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			_builderGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

			_mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Execute_PrototypeGetRobotoMethod_GoldFlow()
		{
			// Arrange
			Roboto roboto = new Roboto();
			var returnValues = new string[] {"4", "1"};
			int index = 0;
			_reader.Setup(x => x.ReadLine()).Returns(() => returnValues[index++]);
			_prototypeGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			Program.Execute(_windsorContainer);

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			_prototypeGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

			_mockRepository.VerifyAll();
		}
	}
}
