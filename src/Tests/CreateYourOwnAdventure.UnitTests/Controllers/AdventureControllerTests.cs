using CreateYourOwnAdventure.Api.Controllers;
using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace CreateYourOwnAdventure.UnitTests.Controllers
{
    [TestClass]
    public class AdventureControllerTests
    {
        private Mock<ILogger<AdventureController>> _mockLogger;
        private Mock<IAdventureService> _mockAdventureService;
        private List<BinaryTree<Question>> _validAdventuresResponse;
        private BinaryTree<Question> _validAdventureResponse;
        private CreateAdventureRequest _validCreateAdventureRequest;
        private int _validAdventureId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLogger = new Mock<ILogger<AdventureController>>();
            _mockAdventureService = new Mock<IAdventureService>();
            _validAdventureId = 1;
        }

        [TestMethod]
        public async Task GetAdventures_ValidResponse()
        {
            //Arrange            
            _validAdventureResponse = BuildSampleAdventureResponse();
            _validAdventuresResponse = new List<BinaryTree<Question>>() { _validAdventureResponse };
            _mockAdventureService.Setup(x => x.Get()).ReturnsAsync(_validAdventuresResponse);

            var systemUnderTest = new AdventureController(_mockLogger.Object, _mockAdventureService.Object);

            //Act
            var adventures = (ObjectResult) await systemUnderTest.Get();

            //Assert
            Assert.That(adventures.Value, Is.EqualTo(_validAdventuresResponse));
        }

        [TestMethod]
        public async Task GetAdventureById_ValidResponse()
        {
            //Arrange
            _validAdventureResponse = BuildSampleAdventureResponse();
            _mockAdventureService.Setup(x => x.Get(_validAdventureId)).ReturnsAsync(_validAdventureResponse);

            var systemUnderTest = new AdventureController(_mockLogger.Object, _mockAdventureService.Object);

            //Act
            var adventure = (ObjectResult)await systemUnderTest.Get(_validAdventureId);

            //Assert
            Assert.That(adventure.Value, Is.EqualTo(_validAdventureResponse));
        }

        [TestMethod]
        public async Task CreateNewAdventure_ValidResponse()
        {
            //Arrange
            _validCreateAdventureRequest = BuildCreateAdventureRequest();
            _mockAdventureService.Setup(x => x.Create(_validCreateAdventureRequest)).ReturnsAsync(_validAdventureId);

            var systemUnderTest = new AdventureController(_mockLogger.Object, _mockAdventureService.Object);

            //Act
            var adventure = (OkResult) await systemUnderTest.Create(_validCreateAdventureRequest);

            //Assert
            Assert.That(adventure.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

        private BinaryTree<Question> BuildSampleAdventureResponse()
        {
            return new BinaryTree<Question>
            {
                BinaryTreeId = 1,
                Root = new BinaryTreeNode<Question>
                {
                    Data = new Question("Do I want a Donut?"),
                    Yes = new BinaryTreeNode<Question>
                    {
                        Data = new Question("Do I deserve it?"),
                        Yes = new BinaryTreeNode<Question>
                        {
                            Data = new Question("Are you sure?"),
                            Yes = new BinaryTreeNode<Question>
                            {
                                Data = new Question("Get it")
                            },
                            No = new BinaryTreeNode<Question>
                            {
                                Data = new Question("Do jumping jacks first!")
                            }
                        },
                        No = new BinaryTreeNode<Question>
                        {
                            Data = new Question("Is it a good donut?"),
                            Yes = new BinaryTreeNode<Question>
                            {
                                Data = new Question("What are you waiting for? Grab it now.")
                            },
                            No = new BinaryTreeNode<Question>
                            {
                                Data = new Question("Wait till you find a sinful, unforgettable doughnut.")
                            }
                        }
                    },
                    No = new BinaryTreeNode<Question>
                    {
                        Data = new Question("Maybe you want an apple?")
                    }
                }
            };
        }

        private CreateAdventureRequest BuildCreateAdventureRequest()
        {
            return new CreateAdventureRequest()
            {
                Question = "Do you want a Donut?",
                Yes = null,
                No = null
            };
        }
    }
}