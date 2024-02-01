using LibraryTask;
using LibraryTask.Exceptions;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        string opt;
        do
        {
            ShowMenu();
            opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    AddBook(library);
                    break;
                case "2":
                    if (library.HasNoBooks())
                    {
                        Console.WriteLine("The library has no books. Cannot remove a book.");
                    }
                    else
                    {
                        RemoveBook(library);
                    }
                    break;
                case "3":
                    if (library.HasNoBooks())
                    {
                        Console.WriteLine("The library has no books.");
                    }
                    else
                    {
                        DisplayAllBooks(library);
                    }
                    break;
                case "4":
                    if (library.HasNoBooks())
                    {
                        Console.WriteLine("The library has no books. Cannot search for a book.");
                    }
                    else
                    {
                        SearchBookForValue(library);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    break;
            }
        } while (opt != "0");


        static void ShowMenu()
        {
            Console.WriteLine("1.Add Book");
            Console.WriteLine("2.Remove Book");
            Console.WriteLine("3.Display All Books");
            Console.WriteLine("4.Search Book");
            Console.WriteLine("0.Exit ");
            Console.Write("Choose the operation:  ");
        }

        static void AddBook(Library library)
        {
        NameForAdd:
            Console.WriteLine("Enter the name for adding :");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Enter valid name!");
                goto NameForAdd;
            }
            try
            {
                library.AddBook(name.Trim());
            }
            catch (DublicateBookException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (LibraryLimitIsFullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void RemoveBook(Library library)
        {
        NameForRemove:
            Console.WriteLine("Enter the name for removing:");
            string nameR = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nameR))
            {
                Console.WriteLine("Enter valid name!");
                goto NameForRemove;
            }
            if (library.RemoveBook(nameR.Trim()))
            {
                Console.WriteLine("Book successfully removed!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        static void DisplayAllBooks(Library library)
        {
            Console.WriteLine("All books: ");
            foreach (var book in library.books)
            {
                Console.WriteLine(book);
            }
        }
        static bool SearchBookForValue(Library library)
        {
            Console.WriteLine("Enter the search value:");
            string searchValue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                Console.WriteLine("Search value cannot be null or whitespace.");
                return false;
            }
            bool foundAny = false;
            Console.WriteLine($"Books containing '{searchValue}':");
            foreach (var book in library.books)
            {
                if (book.Contains(searchValue))
                {
                    Console.WriteLine(book);
                    foundAny = true;
                }
            }
            if (!foundAny)
            {
                Console.WriteLine($"No books containing '{searchValue}' found in the library.");
            }
            return foundAny;
        }

      
    }
}