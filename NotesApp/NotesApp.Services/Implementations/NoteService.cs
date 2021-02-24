using NotesApp.Domain.Models;
using NotesApp.DataAccess;
using NotesApp.Services.Interfaces;
using NotesApp.ViewModels.Note;
using System;
using System.Collections.Generic;
using System.Text;
using NotesApp.Mappers.Note;

namespace NotesApp.Services.Implementations
{
    public class NoteService : INoteService
    {

        private IRepository<Note> _noteRepository;
        private IRepository<Writer> _writerRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<Writer> writerRepository)
        {
            _noteRepository = noteRepository;
            _writerRepository = writerRepository;
        }
        public void CreateNote(NoteViewModel noteViewModel)
        {
            Note note = noteViewModel.ToNote();
            Writer writer = _writerRepository.GetById(note.WriterId);
            if (writer == null)
            {
                //log exception
                throw new Exception($"Writer with id {note.WriterId} was not found!");
            }

            note.Writer = writer;
            int newNoteId = _noteRepository.Insert(note);
            if (newNoteId <= 0)
            {
                throw new Exception("Something went wrong while saving the note");
            }
        }

        public void DeleteNote(int id)
        {
            try
            {
                _noteRepository.DeleteById(id);
            }
            catch
            {
                //log
                throw; // rethrow
            }
        }


        public void EditNote(NoteViewModel noteViewModel)
        {
            Note noteDb = _noteRepository.GetById(noteViewModel.Id);
            if (noteDb == null)
            {
                //log
                throw new Exception($"The note with id {noteViewModel.Id} was not found!");
            }

            Writer writerDb = _writerRepository.GetById(noteViewModel.WriterId);
            if (writerDb == null)
            {
                //log
                throw new Exception($"The writer with id {noteViewModel.WriterId} was not found!");
            }

            Note editedNote = noteViewModel.ToNote();

            editedNote.Writer = writerDb;
            _noteRepository.Update(editedNote);
        }

        public List<NoteDetailsViewModel> GetAllNotes()
        {
            //call to data access layer
            List<Note> notes = _noteRepository.GetAll();
            List<NoteDetailsViewModel> viewModels = new List<NoteDetailsViewModel>();
            foreach (Note note in notes)
            {
                viewModels.Add(note.ToNoteDetailsViewModel());
            }

            return viewModels;
        }

        public NoteDetailsViewModel GetNoteById(int id)
        {
            Note note = _noteRepository.GetById(id);
            if (note == null)
            {
                //log the exception
                throw new Exception($"Note with id {id} does not exist!");
            }

            return note.ToNoteDetailsViewModel();
        }

        public int GetNoteCount()
        {
            List<Note> notesDb = _noteRepository.GetAll();
            return notesDb.Count;
        }

        public NoteViewModel GetNoteForEditing(int id)
        {
            //get from DB
            Note noteDb = _noteRepository.GetById(id);
            if (noteDb == null)
            {
                //log
                throw new Exception($"The note with id {id} was not found!");
            }

            return noteDb.ToNoteViewModel();
        }
    }
}
