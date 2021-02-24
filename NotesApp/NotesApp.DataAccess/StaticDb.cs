using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.DataAccess
{
    public static class StaticDb
    {
        static StaticDb()
        {
            NoteId = 2;
            WriterId = 2;

            Writers = new List<Writer>
            {
                new Writer
                {
                    Id = 1,
                    WriterFirstName = "John",
                    WriterLastName = "Doe"
                },
                new Writer
                {
                    Id = 2,
                    WriterFirstName = "Jessica",
                    WriterLastName = "Doe"
                }

            };
            Notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Title = "What is Lorem Ipsum?",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Writer = Writers[0]
                },
                new Note
                {
                    Id = 2,
                    Title = "What is Lorem Ipsum?",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Writer = Writers[1]
                }

            };

        }

        public static int NoteId { get; set; }
        public static int WriterId { get; set; }

        public static List<Writer> Writers { get; set; }
        public static List<Note> Notes { get; set; }
    }
}

