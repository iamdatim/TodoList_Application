using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace ToDoTask
{

    internal class Program
    {
        static void Main(string[] args)
        {
            


            int itemId = 0;
            List<AddingList> todoList = new List<AddingList>();
            List<User> registeredUsers = new List<User>();
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            Regex regexUsername = new Regex("^[a-zA-Z]+$");
            Regex regexPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8,}$");
            Regex regexps = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$");
            Regex regexChoice = new Regex(@"^\d+$");
            //Regex regexItemTitle = new Regex("^[a-zA-Z]+$");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------- To Do List Application -------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.WriteLine();
                Console.Write("Your Option: ");
                string choice = (Console.ReadLine());


                int value;

                while (!int.TryParse(choice, out value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input, your option should not contain alphabet, character or number.");
                    Console.ResetColor();
                    Console.WriteLine("Please enter a valid option. eg 1,2,3: ");
                    Console.WriteLine();

                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");

                    Console.WriteLine();
                    Console.Write("Your Option: ");
                    choice = (Console.ReadLine());
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("----------------------------------------------- To Do List Application -------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Register(registeredUsers, regex, regexUsername, regexps);
                        break;

                    case "2":
                        Login(todoList, registeredUsers, itemId);
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }



            static void Register(List<User> registeredUsers, Regex regex, Regex regexUsername, Regex regexps)
            {
                Console.Write("Please enter a username: ");
                string username = Console.ReadLine();

                while (!regexUsername.IsMatch(username))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid username format, username must \nnot contain number or character.");
                    Console.ResetColor();
                    Console.Write("Please enter a valid username: ");
                    username = Console.ReadLine();
                }

                Console.Write("Please enter an email address: ");
                string email = Console.ReadLine();

                while (!regex.IsMatch(email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid email address. Please enter a valid email address.");
                    Console.ResetColor();
                    Console.Write("Enter an email address: ");
                    email = Console.ReadLine();
                }


                Console.Write("Please enter a password: ");
                string password = Console.ReadLine();

                while (!regexps.IsMatch(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Password Requiremnet not met, Your Password must contain \nat least 1 Uppercase, Lowercase and Number ");
                    Console.ResetColor();
                    Console.Write("Enter a strong Password: ");
                    password = Console.ReadLine();
                }

                User newUser = new User { Username = username, Email = email, Password = password };
                registeredUsers.Add(newUser);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User registered successfully!");
                Console.ResetColor();
                Console.WriteLine();

                while (registeredUsers.Contains(newUser))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User already exist");
                    break;
                }
            }

            
            static void Login(List<AddingList> todoList, List<User> registeredUsers, int itemId)
            {
                Console.WriteLine("Please enter your Username:");
                string loginUsername = Console.ReadLine();

                Console.WriteLine("Please enter your password:");
                string loginPassword = Console.ReadLine();

                foreach (User user in registeredUsers)
                {
                    if (user.Username == loginUsername && user.Password == loginPassword)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login successful!");
                        Console.ResetColor();
                        bool isChoice = true;
                        while (isChoice)
                        {
                            Console.WriteLine();
                            // Display the todo list menu
                            Console.WriteLine("Todo List Menu:");
                            Console.WriteLine("1. Add New Item");
                            Console.WriteLine("2. View Todo List");
                            Console.WriteLine("3. Edit Existing Item");
                            Console.WriteLine("4. Delete Item");
                            Console.WriteLine("5. Logout");

                            // Get the user's choice

                            Console.WriteLine();
                            Console.Write("Enter your choice: ");
                            string todoChoice = Console.ReadLine();

                            // Process the user's choice
                            int value;

                            while (!int.TryParse(todoChoice, out value))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Input, your option should not contain alphabet, character or number.");
                                Console.ResetColor();
                                Console.WriteLine("Please enter a valid option. eg 1,2,3,4,5: ");
                                Console.WriteLine();

                                Console.WriteLine("Todo List Menu:");
                                Console.WriteLine("1. Add New Item");
                                Console.WriteLine("2. View Todo List");
                                Console.WriteLine("3. Edit Existing Item");
                                Console.WriteLine("4. Delete Item");
                                Console.WriteLine("5. Logout");

                                Console.WriteLine();
                                Console.Write("Your Option: ");
                                todoChoice = Console.ReadLine();
                            }
                            switch (todoChoice)
                            {

                                case "1":
                                    Console.Clear();
                                    // Add a new item to the todo list

                                    Console.Write("Enter the todo Title: ");
                                    string ItemTitle = Console.ReadLine();


                                    //Regex regexItemTitle = new Regex("^[a-zA-Z]+$");

                                    while (string.IsNullOrWhiteSpace(ItemTitle))
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid todo Title format, todo Title must \nnot be empty.");
                                        Console.ResetColor();
                                        Console.Write("Please enter a valid todo Title: ");
                                        ItemTitle = Console.ReadLine();
                                    }

                                    Console.Write("Enter the todo Description: ");
                                    string ItemDescription = Console.ReadLine();

                                    //Regex regexItemDescription = new Regex("^[a-zA-Z0-9]+$");

                                    while (string.IsNullOrWhiteSpace(ItemDescription))
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid todo Description format, todo Title must \nnot be empty.");
                                        Console.ResetColor();
                                        Console.Write("Please enter a valid todo Description: ");
                                        ItemDescription = Console.ReadLine();
                                    }

                                    Console.Write("Enter the todo Due Date (yyyy/MM/dd): ");
                                    string ItemDuedDate = Console.ReadLine();

                                    //DateTime date;
                                    DateTime date = DateTime.Now;
                                    while (!DateTime.TryParse(ItemDuedDate, out date))
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid date format, date must \nbe in this format (yyyy/MM/dd).");
                                        Console.ResetColor();
                                        Console.Write("Please enter a valid date: ");
                                        ItemDuedDate = Console.ReadLine();
                                    }

                                    Console.Write("Enter the todo Priority Level: ");
                                    string ItemPriorityLevel = Console.ReadLine();
                                    //string level = "High", "HIGH";

                                    //Using the Item Tile Regex to validate the Priority Level 
                                    while (string.IsNullOrWhiteSpace(ItemPriorityLevel) && ItemPriorityLevel != "High" || ItemPriorityLevel != "HIGH" || ItemPriorityLevel != "high" ||
                                        ItemPriorityLevel != "Medium" || ItemPriorityLevel != "MEDIUM" || ItemPriorityLevel != "medium" || ItemPriorityLevel != "Low" || ItemPriorityLevel != "LOW" || ItemPriorityLevel != "low")
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid todo Priority Level, todo Priority Level must not contain \ncharacter and must either be High, Medium or Low.");
                                        Console.ResetColor();
                                        Console.Write("Please enter a valid Priority Level: ");
                                        ItemPriorityLevel = Console.ReadLine();
                                    }

                                    AddingList newList = new AddingList { Title = ItemTitle, Description = ItemDescription, DuedDate = ItemDuedDate, PriorityLevel = ItemPriorityLevel };
                                    todoList.Add(newList);
                                    // todoList.Add(new Adding(ItemTitle, ItemDescription, ItemDuedDate, ItemPriorityLevel));

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Item added successfully!");
                                    Console.ResetColor();
                                    break;

                                case "2":
                                    Console.Clear();
                                    // View the current todo list
                                    Console.WriteLine("Todo List:");

                                    Console.WriteLine("|-----|--------------------|--------------------|-------------------------|--------------------|");
                                    Console.WriteLine("|ID   |Title               |Description         |DuedDate                 |PriorityLevel       |");
                                    Console.WriteLine("|-----|--------------------|--------------------|-------------------------|--------------------|");
                                    //Console.WriteLine($"Title: {item.Title}, Description: {item.Description}, DuedDate: {item.DuedDate}, PriorityLevel: {item.PriorityLevel}");

                                    foreach (AddingList item in todoList)
                                    {
                                        int index = todoList.IndexOf(item);

                                        Console.WriteLine("|{0,-5}|{1,-20}|{2,-20}|{3,-25}|{4,-20}|", index + 1, item.Title, item.Description, item.DuedDate, item.PriorityLevel);
                                        Console.WriteLine("|-----|--------------------|--------------------|-------------------------|--------------------|");

                                    }

                                    break;

                                case "3":
                                    // Edit an existing item in the todo list
                                    Console.Write("Enter the item number to edit: ");
                                    //int itemId = int.Parse(Console.ReadLine()) - 1;

                                    itemId = int.Parse(Console.ReadLine());

                                    var itemToEdit = todoList.Find(item => item.Id == itemId);

                                    if (itemToEdit != null)
                                    {
                                        // Display the current properties of the item
                                        Console.WriteLine($"Current Id: {itemToEdit.Id}");
                                        Console.WriteLine($"Current Title: {itemToEdit.Title}");
                                        Console.WriteLine($"Current Description: {itemToEdit.Description}");
                                        Console.WriteLine($"Current Due Date {itemToEdit.DuedDate}");
                                        Console.WriteLine($"Current Priority Level {itemToEdit.PriorityLevel}");

                                        // Get the new values for the item's properties
                                        Console.Write("Enter the new title: ");
                                        itemToEdit.Title = Console.ReadLine();

                                        Console.Write("Enter the new description: ");
                                        itemToEdit.Description = Console.ReadLine();

                                        Console.Write("Enter the new Due Date (yyyy/MM/dd): ");
                                        itemToEdit.DuedDate = Console.ReadLine();

                                        Console.Write("Enter the new Priority Level: ");
                                        itemToEdit.PriorityLevel = Console.ReadLine();

                                        Console.WriteLine("Item edited successfully!");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Item not found.");
                                    }

                                    break;

                                case "4":
                                    // Delete an item from the todo list
                                    Console.Write("Enter the item number to delete: ");
                                    int deleteIndex = int.Parse(Console.ReadLine()) - 1;


                                    if (deleteIndex >= 0 && deleteIndex < todoList.Count)
                                    {
                                        todoList.RemoveAt(deleteIndex);

                                        Console.WriteLine("Item deleted successfully!");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid item number.");
                                    }
                                    break;

                                case "5":
                                    isChoice = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice, please try again.");
                                    break;
                            }

                        }
                        break;


                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid username or password.");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    

                }

                
            }
        }
    }
}
