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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public List<BookModel> SearchBooks(string title, string authorName) 
        {
            return DataSource().Where(x=>x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {Id=1, Title="C Programming", Author="sohan", Description = "This is C Programming book description"},
                new BookModel() {Id=2, Title="Data Structure", Author="afroja", Description = "This isData Structure book description"},
                new BookModel() {Id=3, Title="Algorithm", Author="sohan", Description = "This is Algorithm book description"},
                new BookModel() {Id=4, Title="Database", Author="Saif", Description = "This is Database book description"},
                new BookModel() {Id=5, Title="Networking", Author="Amina", Description = "This is Networking book description"},
                new BookModel() {Id=6, Title=".NET Core MVC", Author="Windows", Description = "This is .NET Core MVC book description"}
            };
        }
    }
}
