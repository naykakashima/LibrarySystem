using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class AudioBook : BookBase
    {
        public int RuntimeMinutes { get; set; }

        public AudioBook(string title, string author, int runtimeMinutes) : base (title, author, available : true)
        {
            RuntimeMinutes = runtimeMinutes;
        }

        public override bool CanBeBorrowed() => base.CanBeBorrowed() && RuntimeMinutes < 300;
        //only allows short audio books
        
    }
}
