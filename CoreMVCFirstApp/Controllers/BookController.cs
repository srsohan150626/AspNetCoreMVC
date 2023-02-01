using CoreMVCFirstApp.Models;
using CoreMVCFirstApp.Repository;
using Microsoft.AspNetCore.Mvc;

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

        public ViewResult AddBook(bool isSuccess=false, int bookId=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            int id = await _bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId= id });
            }
            return View();
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);
        }
    }
}
