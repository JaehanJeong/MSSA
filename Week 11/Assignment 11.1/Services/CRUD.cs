using Assignment_11._1.Data;
using Assignment_11._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_11._1.Services
{
    public static class Records
    {
        public static BookContext context = new BookContext();
    }

    public class CRUD
    {
        public void AddBook(Book book)
        {
            Records.context.Books.Add(book);
            Records.context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return Records.context.Books.ToList();
        }

        public void UpdateBook(Book book)
        {
            var existing = Records.context.Books.FirstOrDefault(b => b.ISBN == book.ISBN);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.AuthorName = book.AuthorName;
                existing.Description = book.Description;
                Records.context.SaveChanges();
            }
        }

        public void DeleteBook(string isbn)
        {
            var book = Records.context.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                Records.context.Books.Remove(book);
                Records.context.SaveChanges();
            }
        }
    }
}