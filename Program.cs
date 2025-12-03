using System;
using System.Collections.Generic;
using System.Resources;
using System.Text.Json;

namespace Contact
{
    class Program
    {
        static void Help()
        {
            List<string> commando = new List<string> //list of the commandos
            {
                "   > contacts - Shows your contacts",
                "   > contact add <name> <number> - Adds a contact",
                "   > contact remove <name> - Removes contact",
                "   > clear - clears what has been written",
                "------------------------------",
                "   > search <name> - shows if that name is in your contacts",
                "   > edit <name> - edits a contact",
                "------------------------------",
                "   > exit - exists the terminal"
            };
            foreach (string i in commando)
            {
                Console.WriteLine(i);
            }
        }

        static void Addcontacts(Dictionary<string, string> contacts, string input) //this methods adds a contact
        {
            string remainingAdd = input.Substring(12).Trim();
            string[] partsAdd = remainingAdd.Split(' ');

            if (partsAdd.Length >= 2)
            {
                string name = partsAdd[0];
                string number = partsAdd[1];

                if (!contacts.ContainsKey(name))
                {
                    contacts.Add(name, number);
                    Console.WriteLine(partsAdd[0] + " was added");
                }
                else
                {
                    Console.WriteLine(partsAdd[0] + " alredy exists");
                }
            }
        }

        static void RemoveContacts(Dictionary<string, string> removecontacts, string input) //this method removes a chosen contact
        {
            string remainingRemove = input.Substring(14).Trim();
            string[] partsRemove = remainingRemove.Split(' ');

            if (!string.IsNullOrEmpty(remainingRemove))
            {
                if (removecontacts.ContainsKey(remainingRemove))
                {
                    removecontacts.Remove(remainingRemove);
                    Console.WriteLine(remainingRemove + " was removed");
                }
                else
                {
                    Console.WriteLine(remainingRemove + " does not exist");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Here is your contact app");
            Console.WriteLine(" > Enter 'contact help' to see the commandos");

            //the contact and their phonenumber is saved here
            Dictionary<string, string> yourContacts = new Dictionary<string, string>();


            while (true)
            {
                Console.Write("~ ");
                string firstInput = Console.ReadLine().ToLower();

                if (firstInput == "contact help") //shows the commando list
                {
                    Help();
                }
                else if (firstInput == "contacts")   //shows the saved contacts
                {
                    if (yourContacts.Count == 0)
                    {
                        Console.WriteLine("There are no contacts added");
                    }
                    else
                    {
                        foreach (var i in yourContacts)
                        {
                            Console.WriteLine($"{i.Key} - {i.Value}");
                        }
                    }
                }


                else if (firstInput.StartsWith("contact add")) 
                {
                    Addcontacts(yourContacts, firstInput);
                }

                else if (firstInput.StartsWith("contact remove"))  //removes a contact
                {
                    RemoveContacts(yourContacts, firstInput);
                }

                else if (firstInput.StartsWith("search")) // looks in the dictionary for that key
                {
                    string remainSearch = firstInput.Substring(7).Trim();
                    string[] searchSplit = remainSearch.Split(' ');

                    if (yourContacts.ContainsKey(remainSearch))
                    {
                        Console.WriteLine($"{remainSearch} is in your contacts. Their phonenumber is: {yourContacts[remainSearch]}");
                    }
                    else
                    {
                        Console.WriteLine($"{remainSearch} is not in your contacts");
                    }
                }

                else if (firstInput == "clear")
                {
                    Console.Clear();
                }
                else if (firstInput == "exit")
                {
                    Console.WriteLine("Bye bye!");
                    Console.Write("-ˋˏ✄┈┈┈┈");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command, please check your spelling.");
                }
            }


        }
    }
}