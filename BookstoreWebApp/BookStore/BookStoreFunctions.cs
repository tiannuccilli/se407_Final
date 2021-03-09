using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class BookStoreFunctions
    {
        public static List<Author> GetAllAuthors()
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Authors.ToList();

            }
        }
        public static List<Genre> GetAllGenres()
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Genres.ToList();

            }
        }
        public static Book GetFullBookById(int id)
        {
            using (var db = new SE407_BookstoreContext())
            {
                var book = db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Where(b => b.BookId == id)
                    .FirstOrDefault();
                return book;
            }
        }
        public static Book GetBookByTitle(String titleStr)
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Books.Where(b => b.BookTitle == titleStr).FirstOrDefault();
            }
        }
        public static List<Book> GetAllBooksFull()
        {
            using (var db = new SE407_BookstoreContext())
            {
                var books = db.Books
                    .Include(books => books.Author)
                    .Include(books => books.Genre)
                    .ToList();

                return books;
            }
        }
        public static List<Book> GetAllBooks()
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Books.ToList();
            }
        }
        public static List<Book> GetAllAuthorBooks(String author)
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Books
                .Join(db.Authors,
                 b => b.AuthorId,
                 a => a.AuthorId,
                 (b, a) => new
                 {
                     BookId = b.BookId,
                     BookTitle = b.BookTitle,
                     GenreId = b.GenreId,
                     AuthorId = b.AuthorId,
                     YearOfRelease = b.YearOfRelease,
                     AuthorLast = a.AuthorLast
                 }).Where(w => w.AuthorLast == author)
                 .Select(b => new Book
                 {
                     BookId = b.BookId,
                     BookTitle = b.BookTitle,
                     GenreId = b.GenreId,
                     AuthorId = b.AuthorId,
                     YearOfRelease = b.YearOfRelease
                 }).ToList();
            }
        }
    }
}
