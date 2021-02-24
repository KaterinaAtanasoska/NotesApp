using NotesApp.ViewModels.Note;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Mappers.Note
{
    public static class NoteMapper
    {
        public static NoteDetailsViewModel ToNoteDetailsViewModel(this Domain.Models.Note note)
        {
            return new NoteDetailsViewModel
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                WriterId = note.WriterId,
                WriterFullName = $"{note.Writer.WriterFirstName} {note.Writer.WriterLastName}"
            };
        }
        public static List<NoteDetailsViewModel> ToNoteDetailsViewModelList(this List<Domain.Models.Note> notes)
        {
            List<NoteDetailsViewModel> viewModels = new List<NoteDetailsViewModel>();
            foreach (Domain.Models.Note note in notes)
            {
                viewModels.Add(note.ToNoteDetailsViewModel());
            }
            return viewModels;
        }

        public static Domain.Models.Note ToNote(this NoteViewModel noteViewModel)
        {
            return new Domain.Models.Note
            {
                Id = noteViewModel.Id,
                Title = noteViewModel.Title,
                Content = noteViewModel.Content,
                WriterId = noteViewModel.WriterId
            };
        }

        public static NoteViewModel ToNoteViewModel(this Domain.Models.Note note)
        {
            return new NoteViewModel
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                WriterId = note.Writer.Id
            };
        }


    }
}