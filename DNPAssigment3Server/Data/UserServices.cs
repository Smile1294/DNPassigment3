using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using DNPAssigment1.Login;
using DNPAssigment2.Persistance;

namespace DNPAssigment2.Data
{

    public class UserService : IUserService

    {
        public IList<User> Users { get; private set; }

      

        private void Seed()
        {
            Users = new[]
            {
                new User
                {
                    Password = "admin",
                    Username = "admin",
                    SecurityLvl = 10,
                    Age = 21
                }
            }.ToList();
        }
        public IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }
        public async Task<User> ValidateUser(string userName, string passWord)
        {
            using (Context dbContext = new Context())
            {
             User user =  dbContext.AUsers.FirstOrDefault(u => u.Username.Equals(userName) && u.Password.Equals(passWord));
             if (user != null)
             {
                 return user;
             } 
             throw new Exception("User not found");
            }
            
        }
    }

}