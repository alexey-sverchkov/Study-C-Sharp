using System;
using System.IO;
using System.Linq;

namespace lab_02.Users
{
    public class User
    {
        /* properties and fields  */
        public String   Login { get; set; }
        public String   Password { get; set; }
        public DateTime CreationDate { get; }

        /* constructors */
        public User(string login, string password, DateTime creationDate)
        {
            Login = login;
            Password = password;
            CreationDate = creationDate;                                   
        }
    }
}
