using NotesApp.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Services.Interfaces
{
    public interface IWriterService
    {
        List<WriterDDViewModel> GetWritersForDropDown();
    }
}
