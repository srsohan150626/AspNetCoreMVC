using CoreMVCFirstApp.Models;

namespace CoreMVCFirstApp.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBook(int id)
        {
            return DataSource().Where(x=>x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string title, string authorName) 
        {
            return DataSource().Where(x=>x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {Id=1, Title="C Programming", Author="sohan"},
                new BookModel() {Id=2, Title="Data Structure", Author="afroja"},
                new BookModel() {Id=3, Title="Algorithm", Author="sohan"},
                new BookModel() {Id=4, Title="Database", Author="Saif"}
            };
        }
    }
}
