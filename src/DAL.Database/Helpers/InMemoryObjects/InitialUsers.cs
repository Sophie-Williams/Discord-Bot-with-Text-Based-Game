﻿using CommonHelpers.Extensions;
using CommonHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using UserService.Domain.Models;

namespace DAL.Database.Helpers.InMemoryObjects
{
    public static class InitialUsers
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Users.Any()) return; // error 
            foreach (var initialUser in GetInitialUsers())
            {
                context.Users.Add(initialUser);
            }
            context.SaveChanges(); // error: Invalid object name "Users" (DbUpdateException, inner: SqlException)
        }

        private static List<User> GetInitialUsers()
        {
            return new List<User>()
            {
                new User(
                    "dev",
                    "", ///TODO: Initial User/Administrator Email (Seed)
                    HashUtils.CreateHashCode("1"),
                    Role.Administrator,
                    HashUtils.CreateReferralCode(),
                    true,
                    new CustomId(new Guid("fe3006d3-9e69-477f-ab96-638bc230a439"))
                ),
                new User(
                    "dev2",
                    "", ///TODO: Initial User/Administrator Email (Seed)
                    HashUtils.CreateHashCode("1"),
                    Role.Administrator,
                    HashUtils.CreateReferralCode(),
                    true,
                    new CustomId(new Guid("fe3006d3-9e69-477f-ab96-638bc230a439"))
                )
            };
        }
    }
}
