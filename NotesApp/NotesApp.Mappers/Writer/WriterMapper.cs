using NotesApp.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Mappers.Writer
{
    public static class WriterMapper
    {
        public static WriterDDViewModel ToWriterDdViewModel(this Domain.Models.Writer writer)
        {
            return new WriterDDViewModel
            {
                Id = writer.Id,
                WriterFullName = $"{writer.WriterFirstName} {writer.WriterLastName}"
            };
        }
    }
}
