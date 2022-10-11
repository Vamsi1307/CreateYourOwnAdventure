using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreateYourOwnAdventure.Core.Models;

namespace CreateYourOwnAdventure.UnitTests.Services
{
    [TestClass]
    public class GameServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IBinaryTreeService> mockBinaryTreeService;
        private Mock<IRepository<BinaryTree<Question>>> mockRepositoryBinaryTreeQuestion;
        private Mock<IRepository<Game?>> mockRepositoryMyAdventure;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Default);

            mockBinaryTreeService = mockRepository.Create<IBinaryTreeService>();
            mockRepositoryBinaryTreeQuestion = mockRepository.Create<IRepository<BinaryTree<Question>>>();
            mockRepositoryMyAdventure = mockRepository.Create<IRepository<Game?>>();
        }

        private GameService CreateService()
        {
            return new GameService(
                mockBinaryTreeService.Object,
                mockRepositoryBinaryTreeQuestion.Object,
                mockRepositoryMyAdventure?.Object);
        }

        [TestMethod]
        public async Task Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            GameService? service = CreateService();
            int id = 0;

            // Act
            GameTraverse? result = await service.Get(id);

            // Assert
            Assert.AreEqual(result, null);
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            GameService? service = CreateService();

            // Act
            List<Game?>? result = await service.Get();

            // Assert
            Assert.AreEqual(result, null);
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            GameService? service = CreateService();
            int adventureId = 0;

            // Assert
            mockRepository.VerifyAll();
        }
    }
}
