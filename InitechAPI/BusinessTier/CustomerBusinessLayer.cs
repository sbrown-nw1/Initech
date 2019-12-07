using InitechAPI.Models;
using LiteDB;
using System;
using System.Collections.Generic;

namespace InitechAPI.BusinessTier
{
    public static class CustomerBusinessLayer
    {
        private static IDBLayer dBLayer;

        public static void Register(IDBLayer dBLayerToRegister)
        {
            dBLayer = dBLayerToRegister ?? throw new ArgumentException("dBLayerToRegister cannot be null");
        }
        
        public static List<Customer> GetCustomers(int page = 1, int pageSize = 2)
        {
            return dBLayer.FindAllEnties<Customer>(page, pageSize);
        }

        public static bool UpdateCustomer(Customer customer, int id)
        {
            return dBLayer.UpdateEntity<Customer>(customer, id);
        }

        public static List<Customer> GetCustomersByAgentId(int agentId, int page, int pageSize)
        {
            return dBLayer.FindAllEntiesByQuery<Customer>(Query.EQ("agent_id", agentId), page, pageSize);
        }

        public static int CreateCustomer(Customer customer)
        {
            return dBLayer.CreateEntity<Customer>(customer);
        }

        public static bool DeleteCustomer(int id)
        {
            return dBLayer.DeleteEntityByQuery<Customer>(Query.EQ("_id", id));
        }
    }
}