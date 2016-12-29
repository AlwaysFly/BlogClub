using Core.Dapper.Provider;
using System;
using System.Collections.Generic;

namespace Core.Dapper
{
    public class Program
    {
        public static void Main(string[] args)
        {

            UserHelper helper = new UserHelper();
            helper.DeleteAll();

            helper.SaveUsers(new List<User>() { new User() { Id = 1, UserName = "Tom", Url = "http://www.baidu.com", Age = 18 } });

            var list = helper.GetUsers();
            foreach (var item in list)
            {
                Console.WriteLine($"用户名：{item.UserName} 链接：{item.Url}");
            }

            helper.SaveUser(new User() { Id = 2, UserName = "Jack", Url = "http://www.sohu.com", Age = 22 });


            list = helper.GetUsers();
            foreach (var item in list)
            {
                Console.WriteLine($"用户名：{item.UserName} 链接：{item.Url}");
            }

            //helper.DeleteUser(1);

            list = helper.GetUsers();
            foreach (var item in list)
            {
                Console.WriteLine($"用户名：{item.UserName} 链接：{item.Url}");
            }


            Console.ReadKey();
        }
    }
}
