using InitechAPI.Models;
using System;
using System.Collections.Generic;

namespace InitechAPI.BusinessTier
{
    public static class AgentBusinessLayer
    {
        private static IDBLayer dBLayer;

        public static void Register(IDBLayer dBLayerToRegister)
        {
            dBLayer = dBLayerToRegister ?? throw new ArgumentException("dBLayerToRegister cannot be null");
        }

        public static Agent GetAgent(int id)
        {
            return dBLayer.FindEntity<Agent>(id);
        }

        public static bool UpdateAgent(int id, Agent agent)
        {
            return dBLayer.UpdateEntity<Agent>(agent, id);
        }

        public static List<Agent> GetAgents(int page, int pageSize)
        {
            return dBLayer.FindAllEnties<Agent>(page, pageSize);
        }

        public static int CreateAgent(Agent agent)
        {
            return dBLayer.CreateEntity<Agent>(agent);
        }
    }
}