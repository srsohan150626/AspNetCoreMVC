using CoreMVCFirstApp.Data;
using CoreMVCFirstApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCFirstApp.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext bookStoreContext) { 
            _context= bookStoreContext;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var Books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach(var book in allbooks) 
                {
                    Books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Title= book.Title,
                        Description= book.Description,
                        Language= book.Language,
                        Category= book.Category,
                        TotalPage= book.TotalPage,
                    });
                }
            }
            return Books;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var book = new Book()
            {
                Author= bookModel.Author,
                Title= bookModel.Title,
                Description= bookModel.Description,
                Category = bookModel.Category,
                Language = bookModel.Language,
                TotalPage = bookModel.TotalPage.HasValue ? bookModel.TotalPage.Value:0,
                CreatedOn = DateTime.Now,
                UpdatedOn= DateTime.Now
            };
           await _context.Books.AddAsync(book);
           await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<BookModel> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Language = book.Language,
                    Category = book.Category,
                    TotalPage = book.TotalPage,
                };
                return bookDetails;
            }
            return null;
           
        }
        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {Id = 1, Title="C Programming", Author="sohan", Description = "This is C Programming book description", Category="Technology", Language="English", TotalPage=300},
                new BookModel() {Id = 2, Title="Data Structure", Author="afroja", Description = "This isData Structure book description", Category="Entertainment", Language="English", TotalPage=300},
                new BookModel() {Id = 3, Title="Algorithm", Author="sohan", Description = "This is Algorithm book description", Category="Bloging", Language="English", TotalPage=300}, 
                new BookModel() {Id = 4, Title = "Database", Author = "Saif", Description = "This is Database book description", Category = "Vloging", Language = "English", TotalPage = 300},
                new BookModel() {Id = 5, Title = "Networking", Author = "Amina", Description = "This is Networking book description", Category = "Technology", Language = "English", TotalPage = 300},
                new BookModel() {Id = 6, Title = ".NET Core MVC", Author = "Windows", Description = "This is .NET Core MVC book description", Category = "Technology", Language = "English", TotalPage = 300}
            };
        }
    }
}
