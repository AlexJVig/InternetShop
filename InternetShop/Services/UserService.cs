﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using InternetShop.Models;

namespace InternetShop.Services
{
    public class UserService
    {
        public LoginResult AttemptLogin(LoginDetails input)
        {
            if (input == null)
            {
                return new LoginResult()
                {
                    LoginSucceeded = false,
                    Token = null
                };
            }
            else
            {
                using (var context = new ShopContext())
                {
                    var userDetails = context.Users.Where(p => p.Username == input.Username).FirstOrDefault();
                    var encryptedPassword = convertToMd5(input.Password);
                    var token = convertToMd5(DateTime.Now.ToString());

                    if (encryptedPassword.Equals(userDetails.Password))
                    {
                        return new LoginResult()
                        {
                            LoginSucceeded = true,
                            Token = token
                        };
                    }
                    else
                    {
                        return new LoginResult()
                        {
                            LoginSucceeded = false,
                            Token = null
                        };
                    }
                }
            }
        }

        public bool DoesUserExists(string username)
        {
            using (var context = new ShopContext())
            {
                return context.Users.Count(u => u.Username == username) > 0;
            }
        }

        public bool Register(RegisterDetails input)
        {
            if (input == null)
                return false;

            using (var context = new ShopContext())
            {
                User user = new User()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Phone = input.Phone,
                    Address = input.Address,
                    ClosestBranchID = input.ClosestBranchID,
                    Username = input.Username,
                    Password = convertToMd5(input.Password),
                    IsAdmin = false
                };

                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        private string convertToMd5(string target)
        {
            var cipher = new MD5CryptoServiceProvider();
            var passwordBytes = Encoding.UTF8.GetBytes(target);

            passwordBytes = cipher.ComputeHash(passwordBytes);

            var sb = new StringBuilder();

            for (int i = 0; i < passwordBytes.Length; i++)
            {
                sb.Append(passwordBytes[i].ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}
