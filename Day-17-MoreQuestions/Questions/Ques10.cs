using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
class User
{
    public int Id { get; set; }
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Department { get; set; }
    public string Roles { get; set; }
    public DateOnly? JoinDate { get; set; }
    public decimal Credit { get; set; }
    public string Status { get; set; }
}
static class UserManager
{
    /*
    * Complete the 'CompareUsers' function below.
    *
    * The function is expected to return two lists which are updat
    ed and inserted.
    * The function accepts two lists usersListInDB and newUsersLis
    t as parameter.
    */
    public static(List<User> updated,List<User> inserted) CompareUsers(List<User> userListInDB,List<User> newUserList)
    {
        List<User> updated = new List<User>();
        List<User> inserted = new List<User>();
        
        foreach (var newUser in newUserList)
        {
            var existingUser = userListInDB.FirstOrDefault(u => u.IdentityNumber == newUser.IdentityNumber);
            if (existingUser != null)
            {
                updated.Add(newUser);
            }
            else
            {
                inserted.Add(newUser);
            }
        }
        
        return (updated, inserted);
    }
}
class Ques10
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        List<User> usersListInDB = new List<User>();
        List<User> newUsersList = new List<User>();
        int userInDbCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < userInDbCount; i++)
        {
            var u = Console.ReadLine().Trim().Split(',');
            var usr = new User()
            {
                Id = string.IsNullOrEmpty(u[0]) ? 0 : Convert.ToInt32(u[0]),
                IdentityNumber = u[1],
                FirstName = u[2],
                LastName = u[3],
                Age = string.IsNullOrEmpty(u[4]) ? 0 : Convert.ToInt32(u[4]),
                BirthDate = string.IsNullOrEmpty(u[5]) ? null : new
            DateOnly(Convert.ToInt32(u[5].Split('.')[0]), Convert.ToInt32(u[5]
            .Split('.')[1]), Convert.ToInt32(u[5].Split('.')[2])),
                Email = u[6],
                Gender = u[7],
                Country = u[8],
                City = u[9],
                Address = u[10],
                ZipCode = u[11],
                PhoneNumber = u[12],
                Department = u[13],
                Roles = u[14],
                JoinDate = string.IsNullOrEmpty(u[15]) ? null : new
            DateOnly(Convert.ToInt32(u[15].Split('.')[0]), Convert.ToInt32(u[15].Split('.')[1]), Convert.ToInt32(u[15].Split('.')[2])),
            Credit = string.IsNullOrEmpty(u[16]) ? 0 : Convert.
            ToDecimal(u[16]),
                Status = u[17]
            };
            usersListInDB.Add(usr);
        }
        int newUsersCount = Convert.ToInt32(Console.ReadLine().Trim
        ());
        for (int i = 0; i < newUsersCount; i++)
        {
            var u = Console.ReadLine().Trim().Split(',');
            var usr = new User()
            {
                Id = string.IsNullOrEmpty(u[0]) ? 0 : Convert.ToInt32(u[0]),
                IdentityNumber = u[1],
                FirstName = u[2],
                LastName = u[3],
                Age = string.IsNullOrEmpty(u[4]) ? 0 : Convert.ToInt32(u[4]),
                BirthDate = string.IsNullOrEmpty(u[5]) ? null : new
            DateOnly(Convert.ToInt32(u[5].Split('.')[0]), Convert.ToInt32(u[5]
            .Split('.')[1]), Convert.ToInt32(u[5].Split('.')[2])),
                Email = u[6],
                Gender = u[7],
                Country = u[8],
                City = u[9],
                Address = u[10],
                ZipCode = u[11],
                PhoneNumber = u[12],
                Department = u[13],
                Roles = u[14],
                JoinDate = string.IsNullOrEmpty(u[15]) ? null : new
            DateOnly(Convert.ToInt32(u[15].Split('.')[0]), Convert.ToInt32(u[15].Split('.')[1]), Convert.ToInt32(u[15].Split('.')[2])),
                Credit = string.IsNullOrEmpty(u[16]) ? 0 : Convert.
            ToDecimal(u[16]),
                Status = u[17]
            };
            newUsersList.Add(usr);
        }

        var (updated, inserted) = UserManager.CompareUsers(usersListInDB, newUsersList);
        textWriter.WriteLine("Updated Users:" + updated.Count);
        textWriter.WriteLine("Inserted Users:" + inserted.Count);
        textWriter.Flush();
        textWriter.Close();
    }
}