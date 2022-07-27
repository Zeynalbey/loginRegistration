﻿using AuthenticationWithClie.ApplicationLogic.Validations;
using AuthenticationWithClie.Database.Repository;
using AuthenticationWithClie.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.ApplicationLogic
{
    public class Authentication
    {
        public static void Register()
        {
            Console.WriteLine("Please enter user's first name : ");
            string firstName = Console.ReadLine();

            Console.Write("Please enter user's last name : ");
            string lastName = Console.ReadLine();

            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();

            Console.Write("Please enter user's password : ");
            string password = Console.ReadLine();

            Console.Write("Please enter user's confirm password : ");
            string confirmPassword = Console.ReadLine();

            Console.WriteLine();

            if (
                UserValidation.IsValidFirstName(firstName)&
                UserValidation.IsValidLastName(lastName) &
                UserValidation.IsValidEmail(email) &
                //UserValidation.IsValidPassword(password, confirmPassword) &  //&& -> shirt cut circuit
                !UserValidation.IsUserExist(email)
               )
            {
                User user = UserRepository.AddUser(firstName, lastName, email, password);
                Console.WriteLine($"User added to system, his/her details are : {user.GetInfo()}");
            }
        }


       

        public static void Login()
        {
            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();

            Console.Write("Please enter user's password : ");
            string password = Console.ReadLine();

            if (UserRepository.IsUserExistByEmailAndPassword(email, password))
            {
                User user = UserRepository.GetUserByEmail(email);
                if (user is Admin)
                {
                    Console.WriteLine($"Admin successfully authenticated : {user.GetInfo()}");
                    Dashboard.AdminPanel();

                    
                }
                else if(user is User)
                {
                    Console.WriteLine($"User successfully authenticated : {user.GetInfo()}");

                    Dashboard.UserPanel();
                }
                else
                {
                    Console.WriteLine("emaili duzgun daxil edin.");
                }
            }
        }


    }
}
