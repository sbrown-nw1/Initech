using System;
using InitechAPI;
using InitechAPI.BusinessTier;
using InitechAPI.Models;
using LiteDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InitechAPIUnitTests
{
    [TestClass]
    public class CustomerBusinessLayerUnitTests
    {
        private Mock<IDBLayer> mockDBLayer;

        [TestInitialize]
        public void Init()
        {
            mockDBLayer = new Mock<IDBLayer>();
            CustomerBusinessLayer.Register(mockDBLayer.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WillThrowExpectedExceptionWhenRegisteringNullDBLayer()
        {
            CustomerBusinessLayer.Register(null);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenGetAll()
        {
            CustomerBusinessLayer.GetCustomers(1, 1);
            mockDBLayer.Verify(m => m.FindAllEnties<Customer>(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenUpdate()
        {
            CustomerBusinessLayer.UpdateCustomer(new Customer(), 1);
            mockDBLayer.Verify(m => m.UpdateEntity<Customer>(It.IsAny<Customer>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenGetByAgentId()
        {
            CustomerBusinessLayer.GetCustomersByAgentId(1, 1, 1);
            mockDBLayer.Verify(m => m.FindAllEntiesByQuery<Customer>(It.IsAny<Query>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenCreate()
        {
            CustomerBusinessLayer.CreateCustomer(new Customer());
            mockDBLayer.Verify(m => m.CreateEntity<Customer>(It.IsAny<Customer>()), Times.Once);
        }

        [TestMethod]
        public void WillCallDBLayerOnceWhenDelete()
        {
            CustomerBusinessLayer.DeleteCustomer(1);
            mockDBLayer.Verify(m => m.DeleteEntityByQuery<Customer>(It.IsAny<Query>()), Times.Once);
        }
    }
}
