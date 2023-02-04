using CoreMVCFirstApp.Models;
using CoreMVCFirstApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreMVCFirstApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        [ViewData]
        public string Title { get; set; }
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> GetAllBooks()
        {
            Title = "All Books";
            var booklist = await _bookRepository.GetAllBooks();
            return View(booklist);

        }
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookRepository.GetBook(id);
            Title = "Book Details " + book.Title;
            return View(book);
        }

        public ViewResult AddBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
               // Language = "Bangla"
            };
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            ViewBag.Languages = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "English", Value="1"},
                new SelectListItem(){Text = "Bangla", Value="2", Selected=true },
                new SelectListItem(){Text = "Arabic", Value="3"},
                new SelectListItem(){Text = "Spanish", Value="4"},
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Languages = getLanguages().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View();
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);
        }
        public List<LanguageModel> getLanguages()
        {
            return new List<LanguageModel>() 
            { 
                new LanguageModel(){Id = 1, Name="English"}, 
                new LanguageModel(){Id = 2, Name="Bangla"}, 
                new LanguageModel(){Id = 3, Name="Arabic"}, 
            };
        }
    }
}
