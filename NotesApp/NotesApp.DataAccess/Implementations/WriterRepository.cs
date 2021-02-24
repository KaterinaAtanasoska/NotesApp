using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp.DataAccess.Implementations
{
    public class WriterRepository : IRepository<Writer>
    {
        public void DeleteById(int id)
        {
            Writer writer = StaticDb.Writers.FirstOrDefault(x => x.Id == id);
            if (writer == null)
            {
                throw new Exception($"The writer with id {id} was not found!");
            }
            //delete record from DB
            StaticDb.Writers.Remove(writer);
        }

        public List<Writer> GetAll()
        {
            return StaticDb.Writers;
        }

        public Writer GetById(int id)
        {
            return StaticDb.Writers.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Writer entity)
        {
            StaticDb.WriterId++;
            entity.Id = StaticDb.WriterId;
            //send the record to the DB
            StaticDb.Writers.Add(entity);
            return entity.Id;
        }

        public void Update(Writer entity)
        {
            Writer writer = StaticDb.Writers.FirstOrDefault(x => x.Id == entity.Id);
            if (writer == null)
            {
                throw new Exception($"The writer with id {entity.Id} was not found!");
            }
            //update the record in DB
            int index = StaticDb.Writers.IndexOf(writer);
            StaticDb.Writers[index] = entity;
        }
    }
}
