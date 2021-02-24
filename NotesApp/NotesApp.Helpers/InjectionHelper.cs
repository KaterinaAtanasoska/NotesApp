using Microsoft.Extensions.DependencyInjection;
using NotesApp.DataAccess.Implementations;
using NotesApp.DataAccess;
using NotesApp.Domain.Models;
using NotesApp.Services.Implementations;
using NotesApp.Services.Interfaces;


namespace NotesApp.Helpers
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<Writer>, WriterRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IWriterService, WriterService>();
        }
    }
}
