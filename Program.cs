using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Contact
{
    class Program
    {
        public static Dictionary<string, string> yourContacts = new Dictionary<string, string>();     //the contact and their phonenumber is saved here
        static void Help()
        {
            List<string> commando = new List<string> //list of the commandos
            {
                "   > contacts - Shows your contacts",
                "   > contact add <name> <number> - Adds a contact",
                "   > contact remove <name> - Removes contact",
                "------------------------------",
                "   > search <name> - shows if that name is in your contacts",
                "   > edit <name> - edits a contact",
                "------------------------------",
                "   > save - saves your added contacts",
                "   > load - loads previously added contacts",
                "------------------------------",
                "   > clear - clears what has been written",
                "   > exit - exists the terminal"
            };
            foreach (string i in commando)
            {
                Console.WriteLine(i);
            }
        }
        static void ShowContacts(Dictionary<string, string> contacts) //this methods shows the contacts saved in your dictionary
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("There are no contacts added");
            }
            else
            {
                foreach (var i in contacts)
                {
                    Console.WriteLine($"{i.Key} - {i.Value}");
                }
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

        static void RemoveContacts(Dictionary<string, string> contacts, string input) //this method removes a chosen contact
        {
            string remainingRemove = input.Substring(14).Trim();
            string[] partsRemove = remainingRemove.Split(' ');

            if (!string.IsNullOrEmpty(remainingRemove))
            {
                if (contacts.ContainsKey(remainingRemove))
                {
                    contacts.Remove(remainingRemove);
                    Console.WriteLine(remainingRemove + " was removed");
                }
                else
                {
                    Console.WriteLine(remainingRemove + " does not exist");
                }
            }
        }

        static void Search(Dictionary<string, string> contacst, string input) //here you can search if a contact is in your contact dictionary
        {
            string remainSearch = input.Substring(7);
            string[] splitSearch = remainSearch.Split(' ');
            if (contacst.ContainsKey(remainSearch))
            {
                Console.WriteLine($"{remainSearch} is in your contacts, their number is {contacst[remainSearch]}");
            }
            else
            {
                Console.WriteLine($"{remainSearch} is not in your contacts");
            }
        }

        static void Edit(Dictionary<string, string> contacts, string input) //a contact can be changed here. It will cahnge both name and number
        {
            string remainEdit = input.Substring(5);
            if (contacts.ContainsKey(remainEdit))
            {
                Console.WriteLine($"What do you want to change {remainEdit} to? <name> <number>");
                Console.Write("~ ");
                string update = Console.ReadLine()!.ToLower();


                string[] partsEdit = update.Split(' ');
                string newName = partsEdit[0];
                string newNumber = partsEdit[1];

                contacts.Remove(remainEdit);
                contacts[newName] = newNumber;

                Console.WriteLine($"{remainEdit} has been edited!");
            }
            else
            {
                Console.WriteLine("You can't update a contact that does not exit.");
            }
        }
        static void Save(Dictionary<string, string> contacts) //saves contacts to a json file so you can load them later 😘
        {
            string filePath = "contacts.json";
            string jsonString = JsonSerializer.Serialize(contacts);
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine("Saving...");
            Console.WriteLine("========================");
            Console.WriteLine("Finished !");
        }
        static void Load() //loads previosuly added contacts
        {
            string filePath = "contacts.json";
            string jsonString = File.ReadAllText(filePath);
            yourContacts = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

            Console.WriteLine("Loading...");
            Console.WriteLine("========================");
            Console.WriteLine("Finished!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Here is your contact app");
            Console.WriteLine(" > Enter 'help' to see the commandos");


            bool running = true;


            while (running)
            {
                Console.Write("~ ");
                string firstInput = Console.ReadLine()!.ToLower();

                switch (firstInput) //the different outputs based on the input you type
                {
                    case "help":
                        Help();
                        break;

                    case "contacts":
                        ShowContacts(yourContacts);
                        break;

                    case string s when s.StartsWith("contact add"):
                        Addcontacts(yourContacts, firstInput);
                        break;

                    case string s when s.StartsWith("contact remove"):
                        RemoveContacts(yourContacts, firstInput);
                        break;

                    case string s when s.StartsWith("search"):
                        Search(yourContacts, firstInput);
                        break;

                    case string s when s.StartsWith("edit"):
                        Edit(yourContacts, firstInput);
                        break;

                    case "clear":
                        Console.Clear();
                        break;

                    case "exit":
                        Console.WriteLine("Bye bye!");
                        Console.Write("-ˋˏ✄┈┈┈┈");
                        running = false;
                        break;

                    case "save":
                        Save(yourContacts);
                        break;

                    case "load":
                        Load();
                        break;

                    default:
                        Console.WriteLine("Invalid command, please check your spelling.");
                        break;

                }

            }


        }
    }
}