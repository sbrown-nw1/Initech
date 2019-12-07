using System;
using InitechAPI;
using InitechAPI.BusinessTier;
using InitechAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InitechAPIUnitTests
{
    [TestClass]
    public class AgentBusinessLayerUnitTests
    {
        private Mock<IDBLayer> mockDBLayer;

        [TestInitialize]
        public void Init()
        {
            mockDBLayer = new Mock<IDBLayer>();
            AgentBusinessLayer.Register(mockDBLayer.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WillThrowExpectedExceptionWhenRegisteringNullDBLayer()
        {
            AgentBusinessLayer.Register(null);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenGetById()
        {
            AgentBusinessLayer.GetAgent(1);
            mockDBLayer.Verify(m => m.FindEntity<Agent>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenUpdate()
        {
            AgentBusinessLayer.UpdateAgent(1, new Agent());
            mockDBLayer.Verify(m => m.UpdateEntity<Agent>(It.IsAny<Agent>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenGetAll()
        {
            AgentBusinessLayer.GetAgents(1, 1);
            mockDBLayer.Verify(m => m.FindAllEnties<Agent>(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenCreate()
        {
            AgentBusinessLayer.CreateAgent(new Agent());
            mockDBLayer.Verify(m => m.CreateEntity<Agent>(It.IsAny<Agent>()), Times.Once);
        }
    }
}
