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
        public List<BookModel> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
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
