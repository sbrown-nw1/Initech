using LiteDB;
using System.Collections.Generic;

namespace InitechAPI
{
    public interface IDBLayer
    {
        T FindEntity<T>(int id);

        List<T> FindAllEnties<T>(int page, int pageSize);

        List<T> FindAllEntiesByQuery<T>(Query query, int page, int pageSize);

        int CreateEntity<T>(T entity);

        bool UpdateEntity<T>(T entity, int id);

        bool DeleteEntityByQuery<T>(Query query);
    }
}