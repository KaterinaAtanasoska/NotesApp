using NotesApp.DataAccess;
using NotesApp.Domain.Models;
using NotesApp.Mappers.Writer;
using NotesApp.Services.Interfaces;
using NotesApp.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Services.Implementations
{
    public class WriterService : IWriterService
    {
        private IRepository<Writer> _writerRepository;

        public WriterService(IRepository<Writer> writerRepository)//used DI -> InjectionHelper
        {
            _writerRepository = writerRepository;
        }
        public List<WriterDDViewModel> GetWritersForDropDown()
        {
            //call the DB
            List<Writer> writers = _writerRepository.GetAll();
            //do the mapping
            List<WriterDDViewModel> writerDdViewModels = new List<WriterDDViewModel>();
            foreach (Writer writer in writers)
            {
                writerDdViewModels.Add(writer.ToWriterDdViewModel());
            }

            return writerDdViewModels;
        }
    }
}
