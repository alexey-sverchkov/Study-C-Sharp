using System;

namespace Labs.FileStorage.Console.Users
{
    public class User
    {
        /* properties and fields  */
        public String   Login { get; set; }
        public String   Password { get; set; }
        public DateTime CreationDate { get; }

        public String DirectoryPath { get; set; }

        /* constructors */
        public User(string login, string password, DateTime creationDate)
        {
            Login = login;
            Password = password;
            CreationDate = creationDate;                                   
        }
    }
}
