using CoreMVCFirstApp.Models;
using CoreMVCFirstApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCFirstApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;

        public BookController() 
        {
            bookRepository= new BookRepository();
        }
      
        public ViewResult GetAllBooks()
        {
            var booklist =  bookRepository.GetAllBooks();
            return View(booklist);

        }
        public ViewResult GetBook(int id)
        {
            var book = bookRepository.GetBook(id);
            return View(book);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return bookRepository.SearchBooks(bookName, authorName);
        }
    }
}
