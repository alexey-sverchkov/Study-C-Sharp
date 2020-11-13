using System;
using System.Collections.Generic;

namespace Labs.FileStorage.Console.Users
{
    public class UserAuthenticationManager
    {
        //  key - username, value - user
        private readonly Dictionary<String, User> users = new Dictionary<string, User>();

        /* Constructors */
        public UserAuthenticationManager()
        {
            // ctor
        }

        public UserAuthenticationManager(Dictionary<String, User> users)
        {
            this.users = users;
        }

        /* Methods  */

        public void AddUser(User user)
        {
            users.Add(user.Login, user);
        }      

        public bool IsUserExists(String username)
        {
            return users.ContainsKey(username);
        }

        // check for user, if exists - check for password correctness
        public bool IsPasswordCorrect(String username, String password)
        {
            if (IsUserExists(username))
            {
                String correctPassword = users[username].Password;
                if (correctPassword.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
