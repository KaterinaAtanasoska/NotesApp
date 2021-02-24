using NotesApp.ViewModels.Note;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Services.Interfaces
{
    public interface INoteService
    {
        List<NoteDetailsViewModel> GetAllNotes();
        NoteDetailsViewModel GetNoteById(int id);
        void CreateNote(NoteViewModel noteViewModel);
        NoteViewModel GetNoteForEditing(int id);
        void EditNote(NoteViewModel noteViewModel);
        void DeleteNote(int id);
        int GetNoteCount();
    }
}
