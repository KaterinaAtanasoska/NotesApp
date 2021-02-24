using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.ViewModels.Note
{
    public class NoteDetailsViewModel
    {
        public int Id { get; set; }
        public string WriterFullName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int WriterId { get; set; }
    }
}
