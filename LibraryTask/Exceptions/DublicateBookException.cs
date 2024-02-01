using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask.Exceptions
{
    public class DublicateBookException : Exception
    {
        public DublicateBookException() : base("This book is already exsists")
        {

        }
    }
}

