using System;

namespace Contact
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here is your contact app");
            Console.WriteLine("> Enter 'contact help' to see the commandos");
            //list of the commandos
            List<string> commando = new List<string>
            {
                " > contacts - Shows your contacts",
                " > contact add <name> <number> - Adds a contact",
                " > contact remove <name> <number> - Removes contact",
                " > save - saves your contacts",
                " > exit - exists the terminal"
            };
            //the contact and their phonenumber is saved here
            Dictionary<string, string> yourContacts = new Dictionary<string, string>();

            while (true)
            {
                Console.Write("> ");
                string firstInput = Console.ReadLine().ToLower();

                if (firstInput == "contact help") //shows the commando list
                {
                    foreach (string i in commando)
                    {
                        Console.WriteLine(i);
                    }
                }
                else if (firstInput == "contacts")   //shows the saved contacts
                {
                    foreach (var i in yourContacts)
                    {
                        Console.WriteLine($"{i.Key} - {i.Value}");
                    }
                }

                else if (firstInput.StartsWith("contact add")) //adds a contact
                {
                    string remainingAdd = firstInput.Substring(12);
                    string[] partsAdd = remainingAdd.Split(' ');

                    if (partsAdd.Length >= 2)
                    {
                        string name = partsAdd[0];
                        string number = partsAdd[1];

                        if (!yourContacts.ContainsKey(name))
                        {
                            yourContacts.Add(name, number);
                        }
                        else
                        {
                            Console.WriteLine($"{name} already exists");
                        }
                    }

                }
                else if (firstInput.StartsWith("contact remove"))  //removes a contact
                {
                    string remainingRemove = firstInput.Substring(14);
                    string[] partsRemove = remainingRemove.Split(' ');

                    if (partsRemove.Length >= 2)
                    {
                        string nameRemove = partsRemove[0];
                        string numberRemove = partsRemove[1];

                        if (!yourContacts.ContainsKey(nameRemove))
                        {
                            yourContacts.Remove(nameRemove);
                            yourContacts.Remove(numberRemove);

                            Console.WriteLine($"{nameRemove} was removed");
                        }
                        else
                        {
                            Console.WriteLine($"{nameRemove} does not exist");
                        }
                    }
                }
                else if(firstInput == "exit")
                {
                    Console.Write("Bye bye!");
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