using System;
using System.Collections.Generic;

public class Person
{
    public string firstName;
    public string lastName;
    public string address;
    public int telNumber;

}

namespace Addressbok
{
    class Program
    {
        List<Person> contacts = new List<Person>();

        void createTestData()
        {
            List<string> firstNames = new List<string>() { "Anna", "Björn", "Stina", "Alex", "Oskar", "Fredrik", "Erik", "John", "Cecilia", "Caroline" };
            List<string> lastNames = new List<string>() { "Nguyen", "Andersson", "Johansson", "Berg", "Phan", "Kim", "Schön", "Ly", "Jansson", "Lee" };


            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                Random random = new Random();
                person.firstName = firstNames[random.Next(firstNames.Count)];
                person.lastName = lastNames[random.Next(lastNames.Count)];

                contacts.Add(person);
            }
        }

        void showPerson()
        {
            Console.Clear();
            foreach (Person person in contacts)
            {
                Console.WriteLine("[" + contacts.IndexOf(person) + "] " + person.firstName + " " + person.lastName);
            }
            Console.ReadKey();
        }

        void addPerson()
        {
            Person person = new Person();
            Console.Clear();
            Console.Write("\nFörnamn: ");
            person.firstName = readLine();

            Console.Clear();
            Console.Write("\nEfternamn: ");
            person.lastName = readLine();

            Console.Clear();
            Console.Write("Adress: ");
            person.address = readLine();

            Console.Clear();
            Console.Write("Tel: ");
            person.telNumber = Convert.ToInt32(Console.ReadLine());

            if (!string.IsNullOrWhiteSpace(person.firstName))
            {
                contacts.Add(person);
            }
        }

        void clearPerson()
        {
            Console.WriteLine("Rensa en person i adressboken: [1]");
            Console.WriteLine("Rensa hela listan: [2]");

            char choice = readKey();
            if (choice == '1')
            {
                showPerson();
                Console.WriteLine("Vilken person vill du ta bort ur listan?");
                contacts.RemoveAt(Int32.Parse(choice.ToString()));
            }

            if (choice == '2')
            {
                Console.WriteLine("Är du säker att du vill rensa hela adressboken? Trycka[J]");
                choice = readKey();
                if (choice == 'j')
                {
                    contacts.Clear();
                }
            }
        }

        void menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"~: ADRESSBOKEN ({contacts.Count} personer) :~\n");
            Console.ResetColor();
            Console.WriteLine("[V]isa personer");
            Console.WriteLine("[L]ägg till person");
            Console.WriteLine("[A]vsluta \n[R]ensa adressboken");
            Console.WriteLine("[S]öka person");

        }

        string searchPerson(string search)
        {
            string listName = "";

            foreach (Person person in contacts)
            {
                if (person.firstName.Contains(search) || person.lastName.Contains(search))
                {
                    listName += person.firstName + " " + person.lastName + " Adress: " + person.address
                    + " Telefon: " + person.telNumber + "\n";
                }
            }
            return listName;
        }

        void findPerson()
        {
            Console.WriteLine("Ange söktext:");
            string search = readLine();
            string result = searchPerson(search);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        char readKey()
        {
            while (true)
            {
                try
                {
                    return Console.ReadKey(true).KeyChar;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Något blev fel. Försök igen!");
                }

            }
        }

        string readLine()
        {
            while (true)
            {
                try
                {
                    return Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Något blev fel. Försök igen!");
                }
            }
        }


        public static void Main()
        {
            Program program = new Program();
            program.createTestData();

            while (true)
            {
                program.menu();
                char choice = program.readKey();

                if (choice == 'v')
                {
                    program.showPerson();
                }
                else if (choice == 'l')
                {
                    program.addPerson();
                }
                else if (choice == 'r')
                {
                    program.clearPerson();
                }
                else if (choice == 's')
                {
                    program.findPerson();
                }
                else if (choice == 'a') Environment.Exit(0);
            }
        }
    }
}

