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
using System.Net;
interface IUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int IncorrectAttempt { get; set; }
    public string Location { get; set; }
}
interface IApplicationAuthState
{
    public List<IUser> RegisteredUsers { get; set; }
    public List<IUser> UsersLoggedIn { get; set; }
    public List<string> AllowedLocations { get; set; }
    string Register(IUser user);
    string Login(IUser user);
    string Logout(IUser user);
}
/*
* These strings can be copied and pasted to avoid typing errors.
* User1@email.com should be replaced with the correct user email.
*
* User1@email.com registered successfully!
* User1@email.com is not registered!
* User1@email.com is not logged in!
* User1@email.com is already registered!
* User1@email.com logged in successfully!
* User1@email.com logged out successfully!
* User1@email.com is already logged in!
* User1@email.com is already logged in from another location!
* User1@email.com is blocked!
* User1@email.com is not allowed to login from this location!
* User1@email.com password is incorrect!
*/
class User : IUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int IncorrectAttempt { get; set; }
    public string Location { get; set; }
    public User(int id, string email, string password, string location)
    {
        Id = id;
        Email = email;
        Password = password;
        Location = location;
        IncorrectAttempt = 0;
    }
}


class ApplicationAuthState : IApplicationAuthState
{
    public List<IUser> RegisteredUsers { get; set; }
    public List<IUser> UsersLoggedIn { get; set; }
    public List<string> AllowedLocations { get; set; }
    public ApplicationAuthState(List<string> allowedLocations)
    {
        AllowedLocations = allowedLocations;
        RegisteredUsers = new List<IUser>();
        UsersLoggedIn = new List<IUser>();
    }

        public string Login(IUser user)
        {
            string result = "";
            IUser person = null;

            foreach (var item in RegisteredUsers)
            {
                if (user.Email == item.Email)
                {
                    person = item;
                    break;
                }
            }

            if (person == null)
            {
                result= "Not found";
                return result;
            }

            if (person.IncorrectAttempt >= 3)
            {
                result= "Blocked";
                return result;
            }
            if (!AllowedLocations.Contains(person.Location))
            {
                result="not allowed from this location";
                return result;
            }
            foreach(var item in UsersLoggedIn)
            {
                if (item.Email == person.Email)
                {
                if (item.Location == person.Location)
                {
                    return result="Already Logged in;";
                }else
                {
                    return result="Already logged in from another location";
                }
                    
                }
                
            }
        if (person.Password != user.Password)
        {
            person.IncorrectAttempt++;
            return result="incorrect password";
        }
        person.IncorrectAttempt=0;
        UsersLoggedIn.Add(person);
        result="logged in successfully";
            
            return result;
            
        }

    public string Logout(IUser user)
    {
        string status = "";
        foreach (var item in UsersLoggedIn)
        {
            if (item.Email == user.Email)
            {
                UsersLoggedIn.Remove(item);
                status = "Logged out";
                return status;
            }

        }
        status = "Login first";
        return status;
    }

    public string Register(IUser user)
    {
        string status = "";
        foreach (var item in RegisteredUsers)
        {
            if (item.Email == user.Email)
            {
                status = "Already Registered";
                return status;
            }

        }

        RegisteredUsers.Add(user);
        status = "Added";
        return status;
    }
}
class Ques9
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        List<IUser> users = new List<IUser>();
        List<string> allowedLocations = new List<string>();
        int allowedLocationCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < allowedLocationCount; i++)
        {
            var a = Console.ReadLine().Trim();
            allowedLocations.Add(a);
        }
        ApplicationAuthState authState = new ApplicationAuthState(allowedLocations);
        int usersCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < usersCount; i++)
        {
            var a = Console.ReadLine().Trim().Split(',');
            users.Add(new User(Convert.ToInt32(a[0]), a[1], a[2], a[3]));
        }
        int actionCount = Convert.ToInt32(Console.ReadLine().Trim()
        );
        for (int i = 0; i < actionCount; i++)
        {
            var a = Console.ReadLine().Trim().Split(':');
            var uIndex = Convert.ToInt32(a[1]);
            if (a[0] == "Register")
            {
                textWriter.WriteLine(authState.Register(users[uIndex]));
            }
            else if (a[0] == "Login")
            {
                textWriter.WriteLine(authState.Login(users[uIndex])
                );
            }
            else if (a[0] == "Logout")
            {
                textWriter.WriteLine(authState.Logout(users[uIndex]));
            }
        }
        textWriter.Flush();
        textWriter.Close();
    }
}