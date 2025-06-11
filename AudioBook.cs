using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class AudioBook : BookBase
    {
        public int runtimeMinutes { get; set; }
        public AudioBook(string title, string author, int runtimeMinutes, bool available) : base (title, author, available)
        {
            this.runtimeMinutes = runtimeMinutes;
        }        

    }
}
