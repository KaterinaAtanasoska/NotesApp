using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}