using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CreateYourOwnAdventure.Core.Models;
using CreateYourOwnAdventure.Core.Interfaces;
using Moq;

namespace CreateYourOwnAdventure.UnitTests.Services
{
    [TestClass]
    public class BinaryTreeServiceTests
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

        private BinaryTreeService CreateService()
        {
            return new BinaryTreeService();
        }

        [TestMethod]
        public void BuildTree_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            BinaryTreeService? service = CreateService();
            CreateAdventureRequest request = null;

            // Act
            BinaryTree<Question>? result = service.BuildTree(request);

            // Assert
            Assert.AreEqual(result.BinaryTreeId, 0);
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            BinaryTreeService? service = CreateService();
            List<char> steps = null;
            BinaryTree<Question>? question = null;

            //Act
            var result = service.Get(question, steps);
            
            // Assert
            Assert.AreEqual(result.Count, 0);
        }
    }
}
