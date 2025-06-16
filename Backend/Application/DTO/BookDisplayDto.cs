using System.Text.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class BookDisplayDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool Available { get; set; }
        public string Type { get; set; } = "Book";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RuntimeMinutes { get; set; }  
    }
}
