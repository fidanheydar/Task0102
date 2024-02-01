using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask.Exceptions
{
    public class LibraryLimitIsFullException:Exception
    {
        public LibraryLimitIsFullException():base("Library limit is reached.")
        {
            
        }
    }
}
