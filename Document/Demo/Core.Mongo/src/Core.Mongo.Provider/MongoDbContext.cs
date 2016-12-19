using MongoDB.Driver;
using System;

namespace Core.Mongo.Provider
{
    public class MongoDbContext
    {
        private static IMongoDatabase db;
        /// <summary>
        /// 设置并获取数据库
        /// </summary>
        /// <param name="urls">连接地址</param>
        /// <param name="databaseName">数据库名称</param>
        /// <returns></returns>
        public static IMongoDatabase SetMongoDatabase(string urls, string databaseName)
        {
            MongoClient client = new MongoClient(urls);
            db = client.GetDatabase(databaseName);
            return client.GetDatabase(databaseName);
        }
        /// <summary>
        /// 获取数据库中的集合(相当于表)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMongoCollection<TEntity> GetMongoCollection<TEntity>(string name)
        {
            IsDbNull();//检测数据库是否存在
            return db.GetCollection<TEntity>(name);
        }
        private static void IsDbNull()
        {
            if (db != null)
                return;
            throw new Exception("the mongodb is null,plese set it on method SetMongoDatabase");
        }
        /// <summary>
        /// 删除集合
        /// </summary>
        /// <param name="name">集合名称</param>
        public static void DropCollection(string name)
        {
            db.DropCollection(name);
        }
    }
}
