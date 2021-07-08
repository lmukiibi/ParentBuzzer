using ParentBuzzer.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ParentBuzzer.Service
{
    public static class UserDB
    {
        private static SQLiteAsyncConnection db;

        public static async void AddMoch()
        {
            await MochData();
        }

        public static async Task<User> AddUser(string userName, string email, string password, string city, int age, bool expectingChild, bool hasChild, DateTime childsBirthDate, string hobbies)
        {
            await Init();
            var user = new User
            {
                UserName = userName,
                Email = email,
                Password = password,
                City = city,
                Age = age,
                ExpectingChild = expectingChild,
                HasChild = hasChild,
                ChildsBirth = childsBirthDate,
                Hobbies = hobbies
            };

            await db.InsertAsync(user);
            return user;
        }

        public static async Task<User> GetUser(string email, string password)
        {
            await Init();

            var user = await db.Table<User>().FirstOrDefaultAsync(_ => _.Email == email && _.Password == password);
            return user;
        }

        public static async Task<IEnumerable<User>> GetUsers(User user)
        {
            await Init();
            var users = await db.Table<User>().Where(c => c.City == user.City).ToListAsync();
            return users;
        }

        public static async Task<bool> IfEmailExists(string email)
        {
            await Init();

            var user = await db.Table<User>().FirstOrDefaultAsync(_ => _.Email == email);
            if (user != null) return true;
            return false;
        }

        public static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "UserData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<User>();
        }

        public static async void ResetAndAddMochData()
        {
            await Init();
            await db.DeleteAllAsync<User>();
            await MochData();
        }
        public static async Task<User> UpdateUser(User user, string userName, string email, string password, string city, int age, bool expectingChild, bool hasChild, DateTime childsBirth, string hobbies)
        {
            await Init();

            user.UserName = userName;
            user.Email = email;
            user.Password = password;
            user.City = city;
            user.Age = age;
            user.ExpectingChild = expectingChild;
            user.HasChild = hasChild;
            user.ChildsBirth = childsBirth;
            user.Hobbies = hobbies;

            await db.UpdateAsync(user);
            return user;
        }
        private static async Task MochData()
        {
            await AddUser("Majsan", "majsan@hotmail.com", "123456", "Malmö", 35, true, true, DateTime.Parse("2019-05-08"), "spela gitarr");
            await AddUser("Kanelbullen", "lasse@hotmail.com", "123456", "Malmö", 33, true, false, DateTime.Parse("2019-02-02"), "spela trumpett");
            await AddUser("Carro90", "carro@hotmail.com", "123456", "Malmö", 30, false, true, DateTime.Parse("2021-07-07"), "koda i c#");
            await AddUser("Lotta", "lotta@hotmail.com", "123456", "Malmö", 32, true, true, DateTime.Parse("2016-11-11"), "Matlagning");
            await AddUser("Britt", "britt@hotmail.com", "123456", "Malmö", 29, false, true, DateTime.Parse("2017-09-11"), "Bilar");
            await AddUser("LisaVisa", "lisavisa@hotmail.com", "123456", "Göteborg", 37, true, true, DateTime.Parse("2017-07-07"), "fotboll");
            await AddUser("Pineapple", "moa@hotmail.com", "123456", "Göteborg", 36, true, true, DateTime.Parse("2018-12-12"), "handboll");
            await AddUser("Maskrosen", "anna@hotmail.com", "123456", "Göteborg", 38, true, true, DateTime.Parse("2020-11-09"), "sola");
            await AddUser("MammaVera", "vera@hotmail.com", "123456", "Göteborg", 39, true, true, DateTime.Parse("2016-01-01"), "Styrkesträning");
            await AddUser("Sandra", "sandra@hotmail.com", "123456", "Göteborg", 28, false, true, DateTime.Parse("2018-06-06"), "Resor");
        }
    }
}