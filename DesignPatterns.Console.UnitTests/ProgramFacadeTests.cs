using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DesignPatternConsole;
using DesignPatterns.Implementations;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DesignPatterns.Console.UnitTests
{
	[TestClass]
	public class ProgramFacadeTests
	{
		private IWindsorContainer _windsorContainer;
		private MockRepository _mockRepository;
		private Mock<IWriter> _writer;
		private Mock<IReader> _reader;
		private Mock<IRobotoProgram> _robotoProgram;
		private IProgramFacade _instance;

		[TestInitialize]
		public void SetUp()
		{
			// Set up mocks
			_mockRepository = new MockRepository(MockBehavior.Strict);

			// We don't really car about the writer for now, Loose is fine...
			_writer = _mockRepository.Create<IWriter>(MockBehavior.Loose);
			_reader = _mockRepository.Create<IReader>();
			_robotoProgram = _mockRepository.Create<IRobotoProgram>();

			// Set up stubs
			_writer.Setup(x => x.WriteLine(It.IsNotNull<string>()));

			// Set up castle windsor
			_windsorContainer = new WindsorContainer();
			_windsorContainer.Register(Component.For<IWriter>().Instance(_writer.Object));
			_windsorContainer.Register(Component.For<IReader>().Instance(_reader.Object));
			_windsorContainer.Register(Component.For<IRobotoProgram>().Instance(_robotoProgram.Object));
			_windsorContainer.Register(Component.For<IProgramFacade>().ImplementedBy<ProgramFacade>().LifestyleTransient());

			// Create instance to test
			_instance = _windsorContainer.Resolve<IProgramFacade>();
		}

		[TestMethod]
		public void Execute_Singleton_GoldFlow()
		{
			// Arrange
			Roboto roboto = new Roboto();
			_reader.Setup(x => x.ReadLine()).Returns("1");
			//_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			_instance.Execute();

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			//_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

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
			//_factoryGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
//			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			_instance.Execute();

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			//_factoryGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
//			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

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
			//_builderGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
//			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			_instance.Execute();

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			//_builderGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
//			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

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
			//_prototypeGetRobotoMethod.Setup(x => x.GetRoboto()).Returns(roboto);
//			_robotoProgram.Setup(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)));

			// Act
			_instance.Execute();

			// Assert
			_reader.Verify(x => x.ReadLine(), Times.Exactly(2));
			//_prototypeGetRobotoMethod.Verify(x => x.GetRoboto(), Times.Once);
//			_robotoProgram.Verify(x => x.Execute(It.Is<IEnumerable<Roboto>>(y => y.Count() == 1 && y.First() == roboto)), Times.Once);

			_mockRepository.VerifyAll();
		}
	}
}
