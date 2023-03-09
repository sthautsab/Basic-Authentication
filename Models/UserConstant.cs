using System.Collections.Generic;

namespace Basic_Authentication.Models
{
    public class UserConstant
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "utsab", Password = "123", Role = "Administrator" },
            new UserModel() { Username = "ramu", Password = "456", Role = "Reader" },
            new UserModel() { Username = "prashant", Password = "69420", Role = "Reader" }

        };
    }
}