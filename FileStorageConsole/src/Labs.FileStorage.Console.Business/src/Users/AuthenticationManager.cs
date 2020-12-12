using System;
using System.Collections.Generic;
using Labs.FileStorage.Console.Domain.Users;

namespace Labs.FileStorage.Console.Business.Users
{
    public class AuthenticationManager
    {
        //  key - username, value - user
        private readonly Dictionary<String, User> users = new Dictionary<string, User>();

        /* Constructors */
        public AuthenticationManager()
        {
            // ctor
        }

        public AuthenticationManager(Dictionary<String, User> users)
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
