using System;
using System.Collections.Generic;
using System.Text;

namespace lab_02.src.Users
{
    public class UserAuthenticationManager
    {
        private Dictionary<String, User> users = new Dictionary<string, User>(); //  key - username, value - user
        

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

        public bool isUserExists(String username)
        {        
            if (users.ContainsKey(username))
            {                
                return true;
            }
            return false;
        }

        // check for user, if exists - check for password correctness
        public bool isPasswordCorrect(String username, String password)
        {
            if (isUserExists(username))
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
