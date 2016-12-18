using Core.Mongo.Provider;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Core.Mongo.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region 初始化
            var db = MongoDbContext.SetMongoDatabase("mongodb://192.168.10.200:27017", "MongoTest");
            #endregion


            #region 准备数据
            List<Role> rList = new List<Role>
                    {
                        new Role
                        {
                            Name="r001", Description="rd001"
                        },
                        new Role
                        {
                            Name="r002",Description="rd002"
                        },
                        new Role
                        {
                            Name="r003",Description="rd003"
                        }
                    };
            List<User> uList = new List<User>
            {
                new User
                {
                    Name="001", Pwd="pwd001"
                },
                new User
                {
                    Name="002",  Pwd="pwd002"
                }
                ,
                new User
                {
                    Name="003", Pwd="pwd003"
                }
                ,
                new User
                {
                    Name="004", Pwd="pwd004"
                }
            };
            List<Permission> pList = new List<Permission>
            {
                 new Permission {  Name="001", Url="001.html" },
                 new Permission {  Name="002", Url="002.html" },
                 new Permission {  Name="003", Url="003.html" },
                 new Permission {  Name="004", Url="004.html" },
                 new Permission {  Name="005", Url="005.html" }
            };
            #endregion

            MongoRepostory<User> repostory = new MongoRepostory<User>();
            //清空集合
            db.DropCollection(typeof(User).Name);

            //执行一次批量添加
            repostory.Add(uList);

            //提交后查询所有数据
            repostory.Commit();
            repostory.FindAll().ToList().ForEach(o =>
            {
                System.Console.WriteLine(o.Name + ":" + o.Pwd + ":" + o.Number);
            });

            //执行一次插入操作
            repostory.Add(new User { Name = "005", Pwd = "uPwd005", Number = 5 });

            //执行一次替换操作
            var user = repostory.FindOne(o => o.Name == "001");
            user.Pwd = "wd001"; user.Number = 10; user.Name = "u001";
            repostory.ReplaceOne(o => o.Name == "001", user);



            var update2 = Builders<User>.Update.Set(o => o.Name, "u002").Set(o => o.Pwd, "wd002").Set(o => o.Number, 20);
            var update3 = Builders<User>.Update.Set(o => o.Name, "u003").Set(o => o.Pwd, "wd003").Set(o => o.Number, 30);
            var update4 = Builders<User>.Update.Set(o => o.Name, "u004").Set(o => o.Pwd, "wd004").Set(o => o.Number, 40);

            //执行3次更新操作
            repostory.Update(o => o.Name == "002", update2);
            repostory.Update(o => o.Name == "003", update3);
            repostory.Update(o => o.Name == "004", update4);

            //执行一次删除操作
            var u = repostory.FindOne(o => o.Name == "002");
            repostory.Remoe(o => o.Id == u.Id);

            //提交
            repostory.Commit();

            //查询所有数据
            repostory.FindAll().ToList().ForEach(o =>
            {
                System.Console.WriteLine(o.Name + ":" + o.Pwd + ":" + o.Number);
            });

            //执行回滚
            repostory.Rollback();
            //查询所有数据---回滚到原来，应该是空的
            System.Console.WriteLine("------------------------回滚到原来，应该是空的-------------------------");
            repostory.FindAll().ToList().ForEach(o =>
            {
                System.Console.WriteLine(o.Name + ":" + o.Pwd + ":" + o.Number);
            });


            System.Console.ReadKey();
        }
    }
}
