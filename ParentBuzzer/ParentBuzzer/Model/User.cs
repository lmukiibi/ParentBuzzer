using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ParentBuzzer.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }

        public int Age { get; set; }
        public bool ExpectingChild { get; set; }
        public bool HasChild { get; set; }
        public DateTime ChildsBirth { get; set; }
        public string Hobbies { get; set; }
    }
}
