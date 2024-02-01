using LibraryTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryTask
{
    public class Library
    {
        public List<string> books = new List<string>();
        const int BookLimit = 30;
        public void AddBook(string bookName)
        {
            if (books.Count < BookLimit && !books.Contains(bookName))
            {
                books.Add(bookName);
            }
            else if (books.Count >= BookLimit)
            {
                throw new LibraryLimitIsFullException();
            }
            else
            {
                throw new DublicateBookException();
            }

        }
        public bool RemoveBook(string bookName)
        {
            if (books.Contains(bookName))
            {
                books.Remove(bookName);
                Console.WriteLine($"Book '{bookName}' removed successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Book '{bookName}' not found in the library.");
                return false;
            }
        }

        public bool HasNoBooks()
        {
            return books.Count == 0;
        }
    }
}

    