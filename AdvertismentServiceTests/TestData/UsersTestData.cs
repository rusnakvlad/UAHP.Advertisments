using Advertisment.DAL.Enteties;
using System;
using System.Collections.Generic;

namespace AdvertismentServiceTests.TestData;
public static class UsersTestData
{
    public static IEnumerable<User> GetUsersTestData() => new List<User>
    {
        new User
        {
            Id = "1",
            Name = "Jon",
            Surname = "Jonson",
            Email = "jj@g.com",
            Phone = "0123232333"
        },
        new User
        {
            Id = "2",
            Name = "Mike",
            Surname = "Harison",
            Email = "mh@g.com",
            Phone = "0887799765"
        },
        new User
        {
            Id = "3",
            Name = "Ana",
            Surname = "Gelager",
            Email = "ang@g.com",
            Phone = "0930385759"
        },
    };
}
