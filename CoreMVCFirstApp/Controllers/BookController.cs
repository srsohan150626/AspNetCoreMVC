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
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult GetAllBooks()
        {
            var booklist =  bookRepository.GetAllBooks();
            return View(booklist);

        }
        public BookModel GetBook(int id)
        {
            return bookRepository.GetBook(id);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return bookRepository.SearchBooks(bookName, authorName);
        }
    }
}
