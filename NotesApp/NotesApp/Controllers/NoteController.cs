using Microsoft.AspNetCore.Mvc;
using NotesApp.Services.Interfaces;
using NotesApp.ViewModels.Note;
using System;
using System.Collections.Generic;

namespace NotesApp.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteService;
        private IWriterService _writerService;

        public NoteController(INoteService noteService, IWriterService writerService)
        {
            _noteService = noteService;
            _writerService = writerService;
        }
        public IActionResult Index()
        {
            List<NoteDetailsViewModel> noteDetailsViewModels = _noteService.GetAllNotes();
            return View(noteDetailsViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                NoteDetailsViewModel noteDetailsViewModel = _noteService.GetNoteById(id.Value);
                return View(noteDetailsViewModel);
            }
            catch (Exception ex)
            {
                return View("ExceptionView");
            }
        }

        public IActionResult CreateNote()
        {
            NoteViewModel noteViewModel = new NoteViewModel();
            ViewBag.Writers = _writerService.GetWritersForDropDown();
            return View(noteViewModel);
        }

        [HttpPost]
        public IActionResult CreateNotePost(NoteViewModel noteViewModel)
        {
            try
            {
                _noteService.CreateNote(noteViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionView");
            }

        }

        public IActionResult EditNote(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                NoteViewModel noteViewModel = _noteService.GetNoteForEditing(id.Value);
                ViewBag.Writers = _writerService.GetWritersForDropDown();
                return View(noteViewModel);
            }
            catch
            {
                return View("ExceptionView");
            }

        }

        [HttpPost]
        public IActionResult EditNotePost(NoteViewModel noteViewModel)
        {
            try
            {
                _noteService.EditNote(noteViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }

        }

        public IActionResult DeleteNote(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                NoteDetailsViewModel noteDetailsViewModel = _noteService.GetNoteById(id.Value);
                return View(noteDetailsViewModel);
            }
            catch
            {
                return View("ExceptionView");
            }
        }

        [HttpPost]
        public IActionResult DeleteNotePost(NoteDetailsViewModel noteDetailsViewModel)
        {
            try
            {
                _noteService.DeleteNote(noteDetailsViewModel.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }
        }

    }

}