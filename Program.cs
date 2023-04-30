using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace todolistapp
{

    internal class Program
    {
        class Adding
        {
            private string ItemTitle;
            private string ItemDescription;
            private DateTime ItemDuedDate;
            private string ItemPriorityLevel;


            public Adding(string ItemTitle, string ItemDescription, DateTime ItemDuedDate, string ItemPriorityLevel)
            {
                this.ItemTitle = ItemTitle;
                this.ItemDescription = ItemDescription;
                this.ItemDuedDate = ItemDuedDate;
                this.ItemPriorityLevel = ItemPriorityLevel;
            }
        }


        //class Reg
        //{
        //    private string loginUsername;
        //    private string loginEmail;
        //    private string loginPassword;
        //}

        //public Reg(string loginUsername, string loginEmail, string loginPassword)
        //{
        //    this.loginUsername = loginUsername;
        //    this.loginEmail = loginEmail;
        //    this.ItemPriorityLevel = loginPassword;
        //}


        static void Main(string[] args)
        {
            List<Adding> todoList = new List<Adding>();
            List<Reg> registeredUsers = new List<Reg>();
            


            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------- To Do List Application -------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            bool isChoice = true;

            while (isChoice)
            {
                Console.WriteLine("Welcome to Todo List App!");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Quit");

                Console.WriteLine();
                Console.WriteLine("Enter Your Choice");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter your username: ");
                        string username = Console.ReadLine();

                        Console.Write("Enter your password: ");
                        string password = Console.ReadLine();

                        //Dictionary<string, string> registeredUsers = new Dictionary<string, string>();
                        registeredUsers.Add(username, password);

                        Console.WriteLine("Registration successful!");
                        break;

                    case 2:
                        Console.Write("Enter your username: ");
                        string loginUsername = Console.ReadLine();

                        Console.Write("Enter your password: ");
                        string loginPassword = Console.ReadLine();

                        //Dictionary<string, string> registeredUsers = new Dictionary<string, string>();
                        if (registeredUsers.ContainsKey(loginUsername) && registeredUsers[loginUsername] == loginPassword)
                        {
                            Console.WriteLine("Login successful!");
                            while (true)
                            {
                                // Display the todo list menu
                                Console.WriteLine("Todo List Menu:");
                                Console.WriteLine("1. Add New Item");
                                Console.WriteLine("2. View Todo List");
                                Console.WriteLine("3. Edit Existing Item");
                                Console.WriteLine("4. Delete Item");
                                Console.WriteLine("5. Logout");

                                // Get the user's choice
                                Console.Write("Enter your choice: ");
                                int todoChoice = int.Parse(Console.ReadLine());

                                // Process the user's choice
                                switch (todoChoice)
                                {


                                    case 1:
                                        // Add a new item to the todo list
                                        Console.Write("Enter the new todo Title: ");
                                        string ItemTitle = Console.ReadLine();

                                        Console.Write("Enter the new todo Description: ");
                                        string ItemDescription = Console.ReadLine();

                                        Console.Write("Enter the new todo Due Date: ");
                                        DateTime ItemDuedDate = DateTime.Parse(Console.ReadLine());

                                        Console.Write("Enter the new todo Priority Level: ");
                                        string ItemPriorityLevel = Console.ReadLine();

                                        //List<Task> todoList = new List<Task>();
                                        todoList.Add(new Adding(ItemTitle, ItemDescription, ItemDuedDate, ItemPriorityLevel));


                                        Console.WriteLine("Item added successfully!");
                                        break;

                                    case 2:
                                        // View the current todo list
                                        Console.WriteLine("Todo List:");
                                        for (int i = 0; i < todoList.Count; i++)
                                        {
                                            Console.WriteLine((i + 1) + ". " + todoList);
                                        }
                                        //Console.WriteLine("|--------------------|----------|------------------|----------|--------------------|----------|");
                                        //Console.WriteLine("|Course & Code       |Unit      |Grade Unit        |Grade     |Weight Point        |Remarks   |");
                                        //Console.WriteLine("|--------------------|----------|------------------|----------|--------------------|----------|");


                                        //for (int i = 0; i < todoList.Count; i++)

                                        //{
                                        //    Console.WriteLine("|{0,-20}|{1,-10}|{2,-18}|{3,-10}|{4,-20}|{5,-10}|", i + 1, ItemTitle, ItemDescription[i], ItemDuedDate[i], ItemPriorityLevel[i]);
                                        //    Console.WriteLine("|--------------------|----------|------------------|----------|--------------------|----------|");

                                        break;

                                    case 3:
                                        // Edit an existing item in the todo list
                                        Console.Write("Enter the item number to edit: ");
                                        int editIndex = int.Parse(Console.ReadLine()) - 1;

                                        if (editIndex >= 0 && editIndex < todoList.Count)
                                        {
                                            Console.Write("Enter the new todo Title: ");
                                            string newItemTitle = Console.ReadLine();

                                            Console.Write("Enter the new todo Description: ");
                                            string newItemDescription = Console.ReadLine();

                                            Console.Write("Enter the new todo Due Date: ");
                                            DateTime newItemDuedDate = DateTime.Parse(Console.ReadLine());

                                            Console.Write("Enter the new todo Priority Level: ");
                                            string newItemPriorityLevel = Console.ReadLine();


                                            // todoList[editIndex]= newItemTitle;
                                            todoList.Add(new Adding(newItemTitle, newItemDescription, newItemDuedDate, newItemPriorityLevel));

                                            Console.WriteLine("Item edited successfully!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid item number.");
                                        }
                                        break;

                                    case 4:
                                        // Delete an item from the todo list
                                        Console.Write("Enter the item number to delete: ");
                                        int deleteIndex = int.Parse(Console.ReadLine()) - 1;

                                        if (deleteIndex >= 0 && deleteIndex < todoList.Count)
                                        {
                                            todoList.RemoveAt(deleteIndex);

                                            Console.WriteLine("Item edited successfully!");

                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid item number.");
                                        }
                                        break;

                                    case 5:
                                        isChoice = false;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice, please try again.");
                                        break;
                                }

                            }
                        }
                        break;

                    case 3:
                        isChoice = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;

                }

            }
        }


    }
}
