using InitechAPI.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InitechAPI
{
    public class DBLayer : IDBLayer
    {
        private static readonly string dbFile = $"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\Initech.db";

        public T FindEntity<T>(int id)
        {
            var collectionString = GetDBCollectionString<T>();

            using (var db = new LiteDatabase(dbFile))
            {
                var col = db.GetCollection<T>(collectionString);
                return col.Find(Query.EQ("_id", id)).FirstOrDefault();
            }
        }

        public List<T> FindAllEnties<T>(int page, int pageSize)
        {
            return FindAllEntiesByQuery<T>(Query.All(), page, pageSize);
        }

        public List<T> FindAllEntiesByQuery<T>(Query query, int page, int pageSize)
        {
            var collectionString = GetDBCollectionString<T>();

            using (var db = new LiteDatabase(dbFile))
            {
                var col = db.GetCollection<T>(collectionString);
                return col.Find(query, skip: (page - 1) * pageSize, limit: pageSize).ToList();
            }
        }

        public int CreateEntity<T>(T entity)
        {
            var collectionString = GetDBCollectionString<T>();

            using (var db = new LiteDatabase(dbFile))
            {
                var col = db.GetCollection<T>(collectionString);
                return col.Insert(entity);
            }
        }

        public bool UpdateEntity<T>(T entity, int id)
        {
            var collectionString = GetDBCollectionString<T>();

            using (var db = new LiteDatabase(dbFile))
            {
                var col = db.GetCollection<T>(collectionString);
                return col.Update(id, entity);
            }
        }

        public bool DeleteEntityByQuery<T>(Query query)
        {
            var collectionString = GetDBCollectionString<T>();

            using (var db = new LiteDatabase(dbFile))
            {
                var col = db.GetCollection<T>(collectionString);
                return col.Delete(query) > 0;
            }
        }

        private static string GetDBCollectionString<T>()
        {
            if (typeof(T) == typeof(Customer))
            {
                return "Customers";
            }
            else if (typeof(T) == typeof(Agent))
            {
                return "Agents";
            }

            throw new ArgumentException("<T> is not a valid DBCollecion entity.");
        }
    }
}