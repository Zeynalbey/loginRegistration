using AuthenticationWithClie.Database.Models;
using AuthenticationWithClie.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.ApplicationLogic
{
    public static partial class Dashboard
    {
        
        public static void AdminPanel()
        {
            
            Console.WriteLine($"/add-user  /update-user " +
                $" /remove-user  /reports  /add-admin  /show-admins " +
                $"  /update-admin  /remove-admin" );


            string command = Console.ReadLine();

            if (command == "/add-user")
            {
                Authentication.Register();
            }
            else if (command == "/update-user")
            {
                Console.WriteLine("deyismek istediyiniz emaili daxil edin.");
                string email = Console.ReadLine();
                User user1 = UserRepository.GetUserByEmail(email);
                if (!(user1 == null && user1 is Admin))
                {
                    Console.Write("adi daxil edin:");
                    string user1Name = Console.ReadLine();
                    Console.Write("Soyadi daxil edin:");
                    string user1LastName = Console.ReadLine();
                    user1.FirstName = user1Name;
                    user1.LastName = user1LastName;
                    Console.WriteLine($"{user1.FirstName} {user1.LastName} changed to {user1Name} {user1LastName}");
                }
                else
                {
                    Console.WriteLine("bu email-i deyismek olmaz.");
                }
            }
            else if (command == "/remove-user")
            {
                Console.WriteLine("silmek istediyiniz userin emailini daxil edin.");
                string removeEmail = Console.ReadLine();
                User user1 = UserRepository.GetUserByEmail(removeEmail);
                if (!(user1 is null && user1 is Admin))
                {
                    UserRepository.Delete(user1);
                    Console.WriteLine($"user1.GetInfo() silindi");
                }
                else
                {
                    Console.WriteLine("bele bir istifadeci yoxdur ve ya admindir.");
                }
                
            }
            else if (command == "/reports")
            {

            }
            else if (command == "/add-admin")
            {
                Console.WriteLine("admin etmek istediyiniz emaili daxil edin.");
                string email = Console.ReadLine();
                User user = UserRepository.GetUserByEmail(email);
                if (!(user is null && user is Admin))
                {
                    UserRepository.Delete(user);
                    Admin admin = new Admin(user.FirstName, user.LastName, user.Email, user.Password, user.Id);
                    UserRepository.AddUser(admin);
                }
                else
                {
                    Console.WriteLine("duzgun email daxil edin.");
                }

            }
            else if (command == "/show-admins")
            {
                UserRepository.ShowAdmins();
            }
            else if (command == "/update-admin")
            {
                UserRepository.UpdateAdmin();
            }
            else if (command == "/remove-admin")
            {
                Console.WriteLine("silmek istediyiniz adminin emailini yazin.");
                string emailDeleteAdmin = Console.ReadLine();
                User user = UserRepository.GetUserByEmail(emailDeleteAdmin);
                if (user is Admin)
                {
                    UserRepository.Delete(user);
                    Console.WriteLine($"{user.FirstName} {user.LastName} silindi.");
                }
            }
        }
    }

    public static partial class Dashboard
    {
        public static void UserPanel()
        {
            Console.WriteLine("/update-info" +" " + "/report-user");
            string command = Console.ReadLine();
           
            if (command == "/update-info")
            {
                string updateEmail = Console.ReadLine();
                User user1 = UserRepository.GetUserByEmail(updateEmail);
                if (user1 is User)
                {
                    Console.WriteLine("yeni adi yazin.");
                    string newName = Console.ReadLine();
                    Console.WriteLine("yeni soyadi yazin.");
                    string newLastName = Console.ReadLine();
                    user1.FirstName = newName;
                    user1.LastName = newLastName;
                }
                else
                {
                    Console.WriteLine("emaili duzgun daxil edin.");
                }
            }
            else if(command == "/report-user")
            {
                //string fromUserEmail = Console.ReadLine();
                //Report user1 = UserRepository.GetUserByEmail();

                //string toUserEmail = Console.ReadLine();
                //Report user2 = UserRepository.GetUserByEmail(toUserEmail);

                //string content = Console.ReadLine();
                //Report 

                //Report report = new Report(user1,user2,);
            }
            else
            {
                Console.WriteLine("Command not found");
            }
        }
    }
}