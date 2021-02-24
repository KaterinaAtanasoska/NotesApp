using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp.DataAccess.Implementations
{
    public class NoteRepository : IRepository<Note>
    {
        public NoteRepository()
        {

        }
        public void DeleteById(int id)
        {
            Note note = StaticDb.Notes.FirstOrDefault(x => x.Id == id);
            if (note == null)
            {
                throw new Exception($"Note with id {id} does not exist!");
            }
            StaticDb.Notes.Remove(note);
        }

        public List<Note> GetAll()
        {
            return StaticDb.Notes;
        }

        public Note GetById(int id)
        {
            return StaticDb.Notes.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Note entity)
        {
            StaticDb.NoteId++;
            entity.Id = StaticDb.NoteId;
            //send the record to the DB
            StaticDb.Notes.Add(entity);
            return entity.Id;
        }

        public void Update(Note entity)
        {
            Note note = StaticDb.Notes.FirstOrDefault(x => x.Id == entity.Id);
            if (note == null)
            {
                throw new Exception($"Note with id {entity.Id} does not exist!");
            }
            //update the record in DB
            int index = StaticDb.Notes.IndexOf(note);
            StaticDb.Notes[index] = entity;
        }
    }
}
