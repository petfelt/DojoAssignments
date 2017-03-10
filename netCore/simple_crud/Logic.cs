using System;
using System.Collections.Generic;
using DbConnection;


namespace DbConnection
{
    public class Logic
    {
        int count = 0;
        public Logic()
        {

            // Run me forever unless you quit.
            while (0 == 0)
            {
                Create();
            }
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("No string given!");
            return input[0].ToString().ToUpper() + input.Substring(1);
        }
        public void ReadAll()
        {

            var returnMe = DbConnection.DbConnector.Query("SELECT * FROM users");
            count = 0;
            foreach (var i in returnMe)
            {
                foreach (var j in i)
                {   
                    if(j.Key.Equals("id")){
                        count = (int)(j.Value);
                        // Making the count equal the value of the last id.
                    }
                    // Format those strings nicely!
                    Console.WriteLine(FirstCharToUpper(j.Key.ToString().Replace("_", " ")) + ": " + j.Value.ToString());
                }
                Console.WriteLine();
            }
        }

        public void Create()
        {
            ReadAll();
            Console.WriteLine("Add a new user, update a user, or quit the program:");
            Console.WriteLine("Type 'quit' to quit, 'update' to update, 'delete' to delete, or a first name to start creating a new user.");
            Console.WriteLine();
            Console.WriteLine("Type the user's first name (or a command):");
            string first_name = Console.ReadLine();
            if (first_name == "quit")
            {
                Environment.Exit(0);
            }
            else if (first_name == "update")
            {
                Update();
            }
            else if (first_name == "delete")
            {
                Delete();
            }
            else
            {
                Console.WriteLine("Now type the user's last name:");
                string last_name = Console.ReadLine();
                DbConnector.Execute("INSERT INTO users(first_name,last_name,created_at) VALUES('" + first_name + "','" + last_name + "',NOW())");
            }
        }

        public void Update()
        {
            Console.WriteLine("Type in the User's ID:");
            string user_id = Console.ReadLine();
            int x = 1;
            if (Int32.TryParse(user_id, out x))
            {
                if (x <= count && x > 0)
                {
                    // Success!
                    Console.WriteLine("What part would you like to update?");
                    Console.WriteLine("Type 'first' or 'last' to edit, or anything else to not edit.");
                    string selection = Console.ReadLine();
                    if (selection == "first")
                    {
                        Console.WriteLine("Write a new first name:");
                        selection = Console.ReadLine();
                        Console.WriteLine("Updating user... (if user was on database)");
                        DbConnector.Execute("UPDATE users SET first_name = '" + selection + "', updated_at = NOW() WHERE id = " + user_id);

                    }
                    else if (selection == "last")
                    {
                        Console.WriteLine("Write a new last name:");
                        selection = Console.ReadLine();
                        Console.WriteLine("Updating user... (if user was on database)");
                        DbConnector.Execute("UPDATE users SET last_name = '" + selection + "', updated_at = NOW() WHERE id = " + user_id);
                    }
                    else
                    {
                        Console.WriteLine("Update cancelled.");

                    }
                }
                else
                {
                    Console.WriteLine("That User ID was out of the Database range!");
                }
            }
            else
            {
                Console.WriteLine("That was not a valid User ID!");
            }
            Console.WriteLine("Returning...\n");
        }

        public void Delete()
        {
            Console.WriteLine("Type in the User's ID:");
            string user_id = Console.ReadLine();
            int x = 1;
            if (Int32.TryParse(user_id, out x))
            {
                if (x <= count && x > 0)
                {
                    // Success!
                    Console.WriteLine("Are you sure you want to delete the user with ID " + user_id + "?");
                    Console.WriteLine("Type 'yes' to continue, or anything else to avoid deletion.");
                    string selection = Console.ReadLine();
                    if (selection == "yes" || selection == "y" || selection == "Yes")
                    {
                        Console.WriteLine("Deleting user... (if user was on database)");
                        DbConnector.Execute("DELETE FROM users WHERE id = " + user_id);
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("That User ID was out of the Database range!");
                }
            }
            else
            {
                Console.WriteLine("That was not a valid User ID!");
            }
            Console.WriteLine("Returning...\n");
        }
    }
}