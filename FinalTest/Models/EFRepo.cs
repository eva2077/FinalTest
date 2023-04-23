using System;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Models
{
    public class EFRepo : IRepo
    {
        private Context _context { get; set; }

        public EFRepo(Context context)
        {
            _context = context;
        }

        public IQueryable<Book> Books
        {
            get { return _context.Books; }
            set { _context.Books = (DbSet<Book>)value; }
        }
        //This is to save changes and add to the list
        public void Add(Book response)
        {
            _context.Add(response);
            _context.SaveChanges();
        }
        //Allow you to edit by grabbing id
        public Book GetById(int id)
        {
            return _context.Books.SingleOrDefault(x => x.BookID == id);
        }
        //allow you to edit (update) the list
        public void UpdateBook(Book response)
        {
            _context.Update(response);
            _context.SaveChanges();
        }
        //delete
        public void Delete(Book response)
        {
            _context.Books.Remove(response);
            _context.SaveChanges();
        }
    }
}

