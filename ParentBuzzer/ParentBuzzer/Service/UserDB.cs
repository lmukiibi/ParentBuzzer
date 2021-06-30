using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using ParentBuzzer.Model;

namespace ParentBuzzer.Service
{
    public static class UserDB
    {
        static SQLiteAsyncConnection db;

        public static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "UserData.db");

            db = new SQLiteAsyncConnection(databasePath);


            //await db.DeleteAllAsync<Product>();

            await db.CreateTableAsync<User>();

        }

        public static async void ResetTable()
        {
            await db.DeleteAllAsync<User>();
        }

        /*
        public static async void AddMoch()
        {
            var moch = await GetProducts();


            List<Product> list = (List<Product>)moch;
            if (list.Count > 0)
                return;
            await MochData();
        }
        */

        public static async Task AddUser(string userName, string email, string password, string city)
        {
            await Init();
            var user = new User
            {
                UserName = userName,
                Email = email,
                Password = password,
                City = city
            };

            await db.InsertAsync(user);
        }
        /*
        public static async Task RemoveProduct(int ID)
        {
            await Init();

            await db.DeleteAsync<User>(ID);
        }
        */
        
        public static async Task<IEnumerable<User>> GetUsers()
        {
            await Init();

            var user = await db.Table<User>().ToListAsync();
            return user;
        }
        /*
        public static async Task<User> GetUser(string email, string password)
        {
            await Init();

            var user = db.Table<User>().FirstOrDefault(user => user.Name == name && user.Password == password);

            var user = await db.Table<User>().FirstOrDefaultAsync();
            return user;


        }*/

        public static async Task<User> GetUser(string email, string password)
        {
            await Init();

            var user = await db.Table<User>().FirstOrDefaultAsync(_ => _.Email == email && _.Password == password); ;
            return user;
        }
    }
}
