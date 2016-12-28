using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Core.Dapper.Provider
{
    public class UserHelper
    {
        private string connStr = "server=192.168.31.110;database=test;uid=root;pwd=blogclub;";

        public void SaveUsers(IEnumerable<User> users)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                foreach (var user in users)
                {
                    // insert new snapshot to the database 
                    conn.Execute(@"insert into user(Id,UserName,Url,Age) values (@Id,@UserName,@Url,@Age);", user);
                }

            }
        }
        public IEnumerable<User> GetUsers()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                //查询数据
                var list = conn.Query<User>("select * from user");

                return list;
            }
        }
        public int SaveUser(User user)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                return conn.QueryFirst<int>("insert into user values(@Id,@UserName,@Url,@Age);select last_insert_id();", user);
            }
        }
        public void DeleteUser(int id)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                conn.Execute("delete from user where Id = @Id;", new { Id = id });
            }
        }

        public void DeleteAll()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                conn.Execute("delete from user ;");
            }
        }
    }
}
