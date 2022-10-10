using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;
using CreateYourOwnAdventure.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.UnitTests.Services
{
    [TestClass]
    public class AdventureServiceTests
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

        private AdventureService CreateService()
        {
            return new AdventureService(
                mockBinaryTreeService.Object,
                mockRepositoryBinaryTreeQuestion.Object,
                mockRepositoryMyAdventure?.Object);
        }

        [TestMethod]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            AdventureService? service = CreateService();
            CreateAdventureRequest request = null;

            // Act
            int result = await service.Create(request);

            // Assert
            Assert.AreEqual(result, 0);
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            AdventureService? service = CreateService();

            // Act
            List<BinaryTree<Question>>? result = await service.Get();

            // Assert
            Assert.AreEqual(result, null);
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            AdventureService? service = CreateService();
            int id = 0;

            // Act
            BinaryTree<Question>? result = await service.Get(id);

            // Assert
            Assert.AreEqual(result, null);
            mockRepository.VerifyAll();
        }
    }
}
