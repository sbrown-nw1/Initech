using InitechAPI.BusinessTier;
using InitechAPI.Models;
using LiteDB;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace InitechAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var initDB = false;

            GlobalConfiguration.Configure(WebApiConfig.Register);

            CustomerBusinessLayer.Register(new DBLayer());
            AgentBusinessLayer.Register(new DBLayer());

            bool.TryParse(ConfigurationManager.AppSettings["InitDB"], out initDB);

            if (initDB)
            {
                InitDB();
            }
        }

        private static void InitDB()
        {
            string dbFile = $"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\Initech.db";

            File.Delete(dbFile);

            using (var db = new LiteDatabase(dbFile))
            {
                using (var sr = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\agents.json"))
                {
                    var agentDocs = JsonSerializer.DeserializeArray(sr).Select(x => x.AsDocument);
                    db.GetCollection("Agents").InsertBulk(agentDocs);
                }

                var agents = db.GetCollection<Agent>("Agents");
                agents.EnsureIndex("_id", unique: true);
                Console.WriteLine(agents.FindAll().Count() + " Agents inserted");

                using (var sr = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\customers.json"))
                {
                    var customerDocs = JsonSerializer.DeserializeArray(sr).Select(x => x.AsDocument);
                    db.GetCollection("Customers").InsertBulk(customerDocs);
                }

                var customers = db.GetCollection<Customer>("Customers");
                customers.EnsureIndex("_id", unique: true);
                customers.EnsureIndex("agent_id", unique: false);
                Console.WriteLine(customers.FindAll().Count() + " Customers inserted");
            }
        }
    }
}
