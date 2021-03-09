using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class BookstoreAdminFuncitons
    {
        public static void EditBook(Book book)
        {
            try
            {
                using (var db = new SE407_BookstoreContext())
                {
                    db.Books.Update(book);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }
        public static void deleteBook(int id)
        {
            try
            {
                using (var db = new SE407_BookstoreContext())
                {
                    var bookToDelete = db.Books.Find(id);
                    db.Books.Remove(bookToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
        }
        public static void addBook(Book book)
        {
            try
            {
                using (var db = new SE407_BookstoreContext())
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }
    }
}
